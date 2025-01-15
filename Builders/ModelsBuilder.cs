using System.Text.Json;
using System.Text.Json.Serialization;
using VSUpdatesCleaner.CatalogModel;

namespace VSUpdatesCleaner.Builders;

public static class ModelsBuilder
{
    public static Catalog BuildCatalogModel(string catalogFilePath)
    {
        using var reader = new StreamReader(catalogFilePath);
        var content = reader.ReadToEnd();

        var jsonOptions = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter<PackageType>() },
            TypeInfoResolver = CatalogJsonSerializerContext.Default
        };

        var catalog = JsonSerializer.Deserialize<Catalog>(content, jsonOptions);

        return catalog ?? throw new JsonException("Incorrect catalog file.");
    }

    public static List<PackageDirectory> BuildPackagesList(string packagesDirectory)
    {
        var directoryList = Directory.GetDirectories(packagesDirectory);

        return directoryList.Select(PackageNameParser.Parse)
            .OfType<PackageDirectory>()
            .ToList();
    }
}