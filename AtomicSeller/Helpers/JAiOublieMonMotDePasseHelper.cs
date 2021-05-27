using System;
using AtomicSeller.Helpers.Security;
using Newtonsoft.Json;

namespace AtomicSeller.Helpers
{
    public class JaiOublieMonMotDePasseToken
    {
        public const int ExpirationDelayInDays = 1;

        public int X503_IdSalarie { get; set; }
        public DateTime DateExpiration { get; set; }
        public string TokenId { get; set; }

        public JaiOublieMonMotDePasseToken()
        {
            DateExpiration = DateTime.Now.AddDays(ExpirationDelayInDays);
        }

        public bool IsValid()
        {
            return DateExpiration > DateTime.Now;
        }
    }

    public static class JAiOublieMonMotDePasseHelper
    {
        private const string PrivateKey = "H=>p6%eA4\\2+!LF\\s\\GYDUcy,Tk)^6PwQ;BUp[W`xmjR7ZU{297_k!hth>Bvs+Ue";

        public static string GenerateURLToken(int x503_IdSalarie, string tokenId)
        {
            try
            {
                var token = new JaiOublieMonMotDePasseToken
                {
                    X503_IdSalarie = x503_IdSalarie,
                    TokenId = tokenId
                };

                // JSON-encode token
                var json = JsonConvert.SerializeObject(token);

                // Encrypt JSON-encoded token
                return Crypto.EncryptStringAES(json, PrivateKey);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /**
         * Will return X503_IdSalarie from encoded token taken from URL query string
         * (if we can decypher it, json-decode it and it is still valid)
         */
        public static int GetX503_IdSalarieFromToken(string encryptedJsonEncodedToken)
        {
            try
            {
                // Decrypt JSON-encoded token
                var jsonEncodedToken = Crypto.DecryptStringAES(encryptedJsonEncodedToken, PrivateKey);

                // JSON-decode
                var token = JsonConvert.DeserializeObject<JaiOublieMonMotDePasseToken>(jsonEncodedToken);

                return token.IsValid() ? token.X503_IdSalarie : -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string GetTokenIdFromToken(string encryptedJsonEncodedToken)
        {
            try
            {
                // Decrypt JSON-encoded token
                var jsonEncodedToken = Crypto.DecryptStringAES(encryptedJsonEncodedToken, PrivateKey);

                // JSON-decode
                var token = JsonConvert.DeserializeObject<JaiOublieMonMotDePasseToken>(jsonEncodedToken);

                return token.IsValid() ? token.TokenId : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
