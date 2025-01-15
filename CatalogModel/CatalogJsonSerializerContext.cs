using System.Text.Json.Serialization;

namespace VSUpdatesCleaner.CatalogModel;

[JsonSerializable(typeof(Catalog))]
public partial class CatalogJsonSerializerContext : JsonSerializerContext;