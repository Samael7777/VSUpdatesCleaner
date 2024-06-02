namespace VSUpdatesCleaner.CatalogModel;

public class Signinfo
{
	public string signatureMethod { get; set; }
	public string digestMethod { get; set; }
	public string digestValue { get; set; }
	public string canonicalization { get; set; }
}