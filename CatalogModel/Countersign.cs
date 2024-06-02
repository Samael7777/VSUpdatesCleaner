namespace VSUpdatesCleaner.CatalogModel;

public class Countersign
{
	public string[] x509Data { get; set; }
	public string timestamp { get; set; }
	public string counterSignatureMethod { get; set; }
	public string counterSignature { get; set; }
}