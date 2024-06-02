namespace VSUpdatesCleaner.CatalogModel;

public class Signature
{
	public Signinfo signInfo { get; set; }
	public string signatureValue { get; set; }
	public Keyinfo keyInfo { get; set; }
	public Countersign counterSign { get; set; }
}