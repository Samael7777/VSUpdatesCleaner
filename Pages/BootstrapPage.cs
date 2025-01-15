using EasyConsole;
using VSUpdatesCleaner.Builders;
using VSUpdatesCleaner.CatalogModel;

namespace VSUpdatesCleaner.Pages;

public class BootstrapPage(Program program, string[] args) : Page("Visual Studio installation source processing...", program)
{
    private const string CatalogFileName = "Catalog.json";
    
    private static readonly string _defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;

    public override void Display()
    {
        base.Display();

        CleanSettings();

        if (args.Length > 1)
        {
            Output.WriteLine(ConsoleColor.Red, "Invalid command line arguments.");
            return;
        }

        SetPackageDirectoryPath();
        SetCatalogFilePath();

        if (!TryBuildCleanerModel()) return;
        
        if (Settings.CleanerModel == null || Settings.CleanerModel.UnusedPackagesCount == 0)
            return;

        Console.WriteLine();

        var key = Input.ReadString("Press D to delete unused packages...");
        
        if (!string.Equals(key, "d", StringComparison.OrdinalIgnoreCase)) 
            return;

        Output.WriteLine("Delete unused packages...");
        var deleted = Settings.CleanerModel.DeleteUnusedGetDeletedBytes();
        Output.WriteLine(ConsoleColor.Green, $"Freed {deleted.ToFileSizeApi()}");
    }

    private void SetPackageDirectoryPath()
    {
        var packageDirectory = args.Length == 1 && IsPackageDirectoryValid(args[0])
            ? args[0]
            : _defaultDirectory;
        
        Output.WriteLine(ConsoleColor.Green, $"Using packages directory : {packageDirectory}");
        
        Settings.PackagesDirectoryPath = packageDirectory;
    }

    private static void SetCatalogFilePath()
    {
        var packagesPath = string.IsNullOrWhiteSpace(Settings.PackagesDirectoryPath)
            ? _defaultDirectory
            : Settings.PackagesDirectoryPath;

        var catalogFileDefaultPath = Path.Combine(packagesPath, CatalogFileName);

        if (File.Exists(catalogFileDefaultPath))
        {
            Output.WriteLine(ConsoleColor.Green, $"Found catalog file : {catalogFileDefaultPath}");
            Settings.CatalogFilePath = catalogFileDefaultPath;
            
            return;
        }

        var catalogFilePath = "";
        while (string.IsNullOrWhiteSpace(catalogFilePath) || !IsCatalogFileValid(catalogFilePath))
        {
            catalogFilePath = Input.ReadString($"Enter catalog file path [{catalogFileDefaultPath}]: ");
            if (string.IsNullOrWhiteSpace(catalogFilePath))
                catalogFilePath = catalogFileDefaultPath;
        }

        Settings.CatalogFilePath = catalogFilePath;
    }

    private static bool TryBuildCleanerModel()
    {
        var catalog = BuildCatalogModel();
        if (catalog == null) return false;

        var packages = LoadPackages();
        if (packages == null) return false;
        
        Output.WriteLine("Scan downloaded packages for unused one...");
        var cleanerModel = new CleanerModel(catalog, packages, Settings.PackagesDirectoryPath);
        
        Output.WriteLine(ConsoleColor.Green, $"Found {cleanerModel.UnusedPackagesCount} unused packages.");
        
        if (cleanerModel.UnusedPackagesCount > 0)
        {
            Output.WriteLine(ConsoleColor.Green, $"Unused packages uses {cleanerModel.WastedSpace.ToFileSizeApi()}");
        }

        Settings.CleanerModel = cleanerModel;

        return true;
    }

    private static Catalog? BuildCatalogModel()
    {
        Output.WriteLine("Loading catalog file...");

        try
        {
            var catalog = ModelsBuilder.BuildCatalogModel(Settings.CatalogFilePath);
            Output.WriteLine(ConsoleColor.Green, $"Loaded {catalog.packages.Length} packages.");

            return catalog;
        }
        catch (Exception e)
        {
            Output.WriteLine(ConsoleColor.Red, $"Error reading catalog file: {e.Message}");
            
            return null;
        }
    }

    private static List<PackageDirectory>? LoadPackages()
    {
        Output.WriteLine("Search for downloaded packages...");

        try
        {
            var packages = ModelsBuilder.BuildPackagesList(Settings.PackagesDirectoryPath);
            Output.WriteLine(ConsoleColor.Green, $"Found {packages.Count} packages.");
           
            return packages;
        }
        catch (Exception e)
        {
            Output.WriteLine(ConsoleColor.Red, $"Error reading local packages: {e.Message}");
            return null;
        }
    }

    private static bool IsPackageDirectoryValid(string path)
    {
        if (Directory.Exists(path)) 
            return true;

        Output.WriteLine(ConsoleColor.Red, "Invalid package directory");
        
        return false;
    }

    private static bool IsCatalogFileValid(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) 
            return false;

        if (File.Exists(path)) 
            return true;

        Output.WriteLine(ConsoleColor.Red, "Invalid catalog file path");
        
        return false;
    }

    private static void CleanSettings()
    {
        Settings.CatalogFilePath = "";
        Settings.PackagesDirectoryPath = "";
        Settings.CleanerModel = null;
    }
}