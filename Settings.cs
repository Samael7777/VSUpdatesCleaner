namespace VSUpdatesCleaner;

public static class Settings
{
    public static string CatalogFilePath { get; set; } = "";
    public static string PackagesDirectoryPath { get; set; } = "";
    public static CleanerModel? CleanerModel { get; set; }
}