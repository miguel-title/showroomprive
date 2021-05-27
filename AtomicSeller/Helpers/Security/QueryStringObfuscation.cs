using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AtomicSeller.Helpers.Security
{
    /**
     * Methods responsible for queryString obfuscation/deobfuscation.
     * These methods may throw exceptions, it is implementing code's duty to catch them accordingly.
     */
    public abstract class QueryStringObfuscation
    {
        public const string Key = "q";

        public static string Obfuscate(string queryString, string sharedSecret)
        {
            // Obfuscate queryString
            var obfuscated = Crypto.EncryptStringAES(queryString, sharedSecret);

            //Debug.WriteLine(obfuscated);

            // UrlEncode obfuscated queryString
            return HttpUtility.UrlEncode(obfuscated);
        }

        public static string Deobfuscate(string obfuscatedqueryString, string sharedSecret)
        {
            // De-urlEncode obfuscated queryString
            var obfuscated = HttpUtility.UrlDecode(obfuscatedqueryString);

            if (obfuscated == null)
                return null;

            // Obfuscated values got from Obfuscate may contain spaces.
            // HttpUtility.UrlDecode replaces "+" with " ": I'm really not OK with this.
            obfuscated = obfuscated.Replace(" ", "+");

            //Debug.WriteLine(obfuscated);

            // De-obfuscate queryString
            return Crypto.DecryptStringAES(obfuscated, sharedSecret);
        }

        public static bool HasSomethingToObfuscate(HttpRequestBase request)
        {
            return request.QueryString.AllKeys.Contains(Key);
        }

        public static bool CanObfuscate(SessionBag sessionBag)
        {
            return sessionBag != null
                && sessionBag.GetQueryStringObfuscationSharedSecret() != null;
        }
    }
}
