namespace VSUpdatesCleaner.CatalogModel;

public class Package
{
	public string id { get; init; }
	public Version version { get; init; }
	public PackageType type { get; init; }
}