using System.Collections.Immutable;
using VSUpdatesCleaner.CatalogModel;
using VSUpdatesCleaner.Exceptions;

namespace VSUpdatesCleaner;

public static class PackageNameParser
{
	private const char AttributesSeparator = ',';  
	private const char ValuesSeparator = '=';

	public static PackageDirectory? Parse(string path)
	{
		if(string.IsNullOrWhiteSpace(path)) return null;

		var directoryName = Path.GetFileName(path);
		
		try
		{
			var attributes = GetAttributes(directoryName);
			var directorySize = GetDirectorySize(path);

			var package = new PackageDirectory()
			{
				id = attributes["Id"],
				version = new Version(attributes["version"]),
				DirectoryName = directoryName,
				type = PackageType.Unknown,
				ComponentSize = directorySize,
				Attributes = attributes,
			};

			return package;
		}
		catch(Exception e) when (e is KeyNotFoundException or ParserException)
		{
			return null;
		}
	}

	private static IReadOnlyDictionary<string, string> GetAttributes(string directoryName)
	{
		var attributes = new Dictionary<string, string>();

		var parts = directoryName.Split(AttributesSeparator);
		
		attributes.Add("Id", parts[0]);
		
		foreach (var part in parts[1..])
		{
			var pair = part.Split(ValuesSeparator);
			if (pair.Length != 2) 
				throw new ParserException($"Incorrect directory name {directoryName}"); //Not package

			attributes.Add(pair[0], pair[1]);
		}

		return attributes.ToImmutableDictionary();
	}

	private static long GetDirectorySize(string dirPath)
	{
		var files =
			Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);

		return files.Select(file => new FileInfo(file))
			.Where(fileInfo => fileInfo.Exists)
			.Sum(fileInfo => fileInfo.Length);
	}
}