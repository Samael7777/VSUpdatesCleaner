/* --- Taked from http://www.csharphelper.com/howtos/howto_file_size_in_words.html ---*/

using System.Runtime.InteropServices;
using System.Text;

namespace VSUpdatesCleaner;

public static class PrettySizeFormatter
{
	[DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
	private static extern int StrFormatByteSize(
		long fileSize,
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
		int bufferSize);

	public static string ToFileSizeApi(this long fileSize)
	{
		var sb = new StringBuilder(20);
		StrFormatByteSize(fileSize, sb, 20);
		return sb.ToString();
	}
}