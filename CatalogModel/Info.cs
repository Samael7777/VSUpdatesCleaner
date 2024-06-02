namespace VSUpdatesCleaner.CatalogModel;


public class Info
{
	public string id { get; set; }
	public string buildBranch { get; set; }
	public string buildVersion { get; set; }
	public string localBuild { get; set; }
	public string manifestName { get; set; }
	public string manifestType { get; set; }
	public string productDisplayVersion { get; set; }
	public string productLine { get; set; }
	public string productLineVersion { get; set; }
	public string productMilestone { get; set; }
	public string productMilestoneIsPreRelease { get; set; }
	public string productName { get; set; }
	public string productPatchVersion { get; set; }
	public string productPreReleaseMilestoneSuffix { get; set; }
	public string productSemanticVersion { get; set; }
}
