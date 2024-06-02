using VSUpdatesCleaner.CatalogModel;

namespace VSUpdatesCleaner;

public class PackageDirectory : Package
{
	public IReadOnlyDictionary<string, string> Attributes { get; init; } 

	public string DirectoryName { get; init; }
	
	public long ComponentSize { get; init; }
}