namespace VSUpdatesCleaner.CatalogModel;

public class Catalog
{
	public string manifestVersion { get; set; }
	public string engineVersion { get; set; }
	public Signer[] signers { get; set; }
	public Package[] packages { get; set; }
	public Dictionary<string, string> deprecate { get; set; }
	public Signature signature { get; set; }
}