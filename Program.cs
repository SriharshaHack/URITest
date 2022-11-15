

using System.Web;
/**
* Find all possible characters that can be controlled by a relative URI taking over Absolute URI in URI(baseUri, relativeUri)
*/
namespace URITest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCase1();
            //TestCase2();
        }

        // Test with single character 
        static void TestCase1()
        {
            var baseUri = new Uri("https://foo.com");
            for (int i = 0x0000; i <= 0x10FFFF; i++)
            {
                    try
                    {
                        var relUri = $"{(char)i}//microsoft.com";
                        var _uri = new Uri(baseUri, new Uri(relUri, UriKind.Relative));
                        //Console.WriteLine(_uri.Authority);
                        if (!_uri.Authority.StartsWith("foo"))
                            Console.WriteLine($"\n[+]Success: (Decimal){i}, (Hex)0x{i.ToString("X")}: {(char)i} \n[+]Expoloitable String (URL Encoded): {HttpUtility.UrlEncode(relUri)}");
                    }
                    catch (Exception ex)
                    {
                       // Console.WriteLine($"[!]Error: {ex.Message}. -- i:{i}: {(char)i}");
                    }
               
            }
        }

        // Test with two character combination
        static void TestCase2()
        {
            var baseUri = new Uri("https://foo.com");
            for (int i = 0x0000; i <= 0x10FFFF; i++)
            {
                for (int j = 0x0000; j <= 0x10FFFF; j++)
                {
                    try
                    {
                        var _uri = new Uri(baseUri, new Uri($"{(char)i}{(char)j}microsoft.com/test/path", UriKind.Relative));
                        //Console.WriteLine(_uri.Authority);
                        if (!_uri.Authority.StartsWith("foo"))
                            Console.WriteLine($"{i}, {j}: {(char)i}, {(char)j} : {_uri}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}. -- {i}:{(char)i}, {j}:{(char)j}");
                    }
                }
            }
        }
    }
}