using System.Buffers.Text;
using System.Text;

namespace DotnetLibraryPreview9;

public class NewBase64Url
{
    public NewBase64Url()
    {
        byte[] stringToEncode = Encoding.UTF8.GetBytes("Sample text");

        var unsafeEncoding = Convert.ToBase64String(stringToEncode);

        //More straightforward for usage for example in URLs, as querystrings
        var safeEncoding = Base64Url.EncodeToString(stringToEncode);

        Console.WriteLine($"Unsafe encoding: {unsafeEncoding}"); //U2FtcGxlIHRleHQ=
        Console.WriteLine($"Safe encoding: {safeEncoding}");     //U2FtcGxlIHRleHQ
    }
}
