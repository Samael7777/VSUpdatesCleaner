using VSUpdatesCleaner.CatalogModel;

namespace VSUpdatesCleaner;

public class PackageComparer : IEqualityComparer<Package>
{
	public bool Equals(Package? x, Package? y)
	{
		if (x is null) return false;
		if (y is null) return false;
		if (ReferenceEquals(x, y)) return true;

		return string.Equals(x.id, y.id, StringComparison.OrdinalIgnoreCase)
		       && x.version.Equals(y.version);
	}

	public int GetHashCode(Package obj)
	{
		if (obj is null) throw new ArgumentNullException(nameof(obj));
		return HashCode.Combine(obj.id, obj.version);
	}
}