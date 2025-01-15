/* --- Taked from http://www.csharphelper.com/howtos/howto_file_size_in_words.html ---*/

using System.Runtime.InteropServices;

namespace VSUpdatesCleaner;

public static partial class PrettySizeFormatter
{
	[LibraryImport("Shlwapi.dll",EntryPoint = "StrFormatByteSizeW", StringMarshalling = StringMarshalling.Utf8)]
	private static partial int StrFormatByteSize(
		long fileSize,
		[MarshalAs(UnmanagedType.LPTStr)] string buffer,
		int bufferSize);

	public static string ToFileSizeApi(this long fileSize)
	{
		var buffer = new string('\0', 20);
		_ = StrFormatByteSize(fileSize, buffer, 20);
		return buffer;
	}
}