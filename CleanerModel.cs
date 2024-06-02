using VSUpdatesCleaner.CatalogModel;

namespace VSUpdatesCleaner;

public class CleanerModel
{
    private readonly string _packagesDirectory;
    private readonly List<PackageDirectory> _unusedPackages;

    public long WastedSpace { get; }
    public int UnusedPackagesCount => _unusedPackages.Count;

    public CleanerModel(Catalog catalog, IEnumerable<PackageDirectory> packages, string packagesDirectory)
    {
        _packagesDirectory = packagesDirectory;

        _unusedPackages = packages.Where(dp => 
                !catalog.packages.Contains(dp, new PackageComparer()))
            .ToList();
        
        WastedSpace = _unusedPackages.Sum(p => p.ComponentSize);
    }
    
    public long DeleteUnusedGetDeletedBytes()
    {
        var deletedBytes = 0L;
        foreach (var package in _unusedPackages)
        {
            var targetDirectory = Path.Combine(_packagesDirectory, package.DirectoryName);
            Directory.Delete(targetDirectory, true);
            deletedBytes += package.ComponentSize;
        }

        return deletedBytes;
    }

    public int MoveUnusedGetCount(string targetPath)
    {
        var moved = 0;
        foreach (var package in _unusedPackages)
        {
            var targetDirectory = package.DirectoryName;
            var sourcePath = Path.Combine(_packagesDirectory, targetDirectory);
            var destPath = Path.Combine(targetPath, targetDirectory);

            Directory.Move(sourcePath, destPath);
            moved++;
        }

        return moved;
    }
}