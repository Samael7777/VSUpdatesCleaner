// ReSharper disable LocalizableElement

using System.CommandLine;
using System.CommandLine.Invocation;
using VSUpdatesCleaner.Builders;
using VSUpdatesCleaner.CatalogModel;

namespace VSUpdatesCleaner;

static class Program
{
    private const string CatalogFileName = "Catalog.json";
    private static readonly string AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
    
    static void Main(string[] args)
    {
        var rootCommand = new RootCommand("Visual Studio local packages cleaner.");

        var catalogPathOption = new Option<string>("--catalog-file",
            () => Path.Combine(AppDirectory, CatalogFileName), 
            "Path to Catalog.json.");
        catalogPathOption.AddValidator(result =>
        {
            var value = result.GetValueForOption(catalogPathOption);
            if (string.IsNullOrWhiteSpace(value) || !File.Exists(value))
            {
                result.ErrorMessage = "Catalog file not found.";
            }
            
        });
        rootCommand.AddGlobalOption(catalogPathOption);

        var packagesPathOption = new Option<string>("--packages-path", 
            ()=> AppDirectory,
            "Path to downloaded packages directory.");
        packagesPathOption.AddValidator(result =>
        {
            var value = result.GetValueForOption(packagesPathOption);
            if (string.IsNullOrWhiteSpace(value) || !Directory.Exists(value))
            {
                result.ErrorMessage = "Local packages not found.";
            }
        });
        rootCommand.AddGlobalOption(packagesPathOption);

        var infoCommand = new Command("info", "Print unused packages information (default).");
        rootCommand.AddCommand(infoCommand);

        var deleteCommand = new Command("delete", "Delete unused packages.");
        rootCommand.AddCommand(deleteCommand);

        var moveCommand = new Command("move", "Move unused packages to target directory.");
        var targetDirectoryArgument = new Argument<string>("target", "Target directory for moving packages.");
        targetDirectoryArgument.AddValidator(result =>
        {
            var targetDirectory = result.GetValueForArgument(targetDirectoryArgument);
            if (string.IsNullOrWhiteSpace(targetDirectory))
            {
                result.ErrorMessage = "Target directory not set.";
                return;
            }

            var packagesDirectory = result.GetValueForOption(packagesPathOption);
            if (string.Equals(targetDirectory, packagesDirectory, StringComparison.OrdinalIgnoreCase))
            {
                result.ErrorMessage = "Packages directory and target directory must be different.";
            }
        });
        
        moveCommand.AddArgument(targetDirectoryArgument);
        rootCommand.AddCommand(moveCommand);
        
        infoCommand.SetHandler(context =>
        {
            _ = BuildCleanerModelPrintInfo(context, catalogPathOption, packagesPathOption);
        });

        deleteCommand.SetHandler(context =>
        {
            var cleanerModel = BuildCleanerModelPrintInfo(context, catalogPathOption, packagesPathOption);
            if (cleanerModel is null) return;
            
            Console.WriteLine("Delete unused packages...");
            var deleted = cleanerModel.DeleteUnusedGetDeletedBytes();
            Console.WriteLine($"Freed {deleted.ToFileSizeApi()}");
        });

        moveCommand.SetHandler(context =>
        {
            var cleanerModel = BuildCleanerModelPrintInfo(context, catalogPathOption, packagesPathOption);
            if (cleanerModel is null) return;

            var targetPath = context.ParseResult.GetValueForArgument(targetDirectoryArgument);
            Console.WriteLine($"Move unused packages to {targetPath}...");

            var packagesMoved = cleanerModel.MoveUnusedGetCount(targetPath);
            Console.WriteLine($"Moved {packagesMoved} packages.");
        });

        rootCommand.SetHandler(context => infoCommand.Handler?.Invoke(context));

        rootCommand.Invoke(args);
    }

    private static CleanerModel? BuildCleanerModelPrintInfo(InvocationContext context, Option<string>catalogPathOption, Option<string>packagesPathOption)
    {
        var catalogFilePath = context.ParseResult.GetValueForOption(catalogPathOption)!;
        var packagesDirectory = context.ParseResult.GetValueForOption(packagesPathOption)!;

        Console.WriteLine("Loading catalog file...");
        Catalog catalog;
        try
        {
            catalog = ModelsBuilder.BuildCatalogModel(catalogFilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading catalog file: {e.Message}");
            return null;
        }
        Console.WriteLine($"Loaded {catalog.packages.Length} packages.");

        Console.WriteLine("Search for downloaded packages...");
        List<PackageDirectory> packages;
        try
        {
           packages = ModelsBuilder.BuildPackagesList(packagesDirectory);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading local packages: {e.Message}");
            return null;
        }
        Console.WriteLine($"Found {packages.Count} packages.");

        Console.WriteLine("Scan downloaded packages for unused one...");
        var cleanerModel = new CleanerModel(catalog, packages, packagesDirectory);
        Console.WriteLine($"Found {cleanerModel.UnusedPackagesCount} unused packages.");
        
        if (cleanerModel.UnusedPackagesCount > 0)
        {
            Console.WriteLine($"Unused packages uses {cleanerModel.WastedSpace.ToFileSizeApi()}");
        }

        return cleanerModel;
    }
}