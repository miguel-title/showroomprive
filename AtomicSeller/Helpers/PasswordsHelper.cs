using System.Text.RegularExpressions;

namespace AtomicSeller.Helpers
{
    public class PasswordsHelper
    {
        /**
         * Returns null if password strength is sufficent.
         * Else, return the reason (in a french user-readable way)
         */
        public static string IsPasswordSalarieStrongEnough(int numCaisse, string password)
        {
            /*switch (numCaisse)
            {
                case 34:
                    // ...
                case 35:
                    // ...
            }*/

            // At least 8 chars
            if (password.Length < 8)
                return "Le mot de passe doit contenir au moins 8 caractères.";

            // At least 1 number & 1 letter char
            var digitRegex = new Regex("\\d+");
            var letterRegex = new Regex("[a-zA-Z]");

            if (!digitRegex.Match(password).Success)
                return "Le mot de passe doit contenir au moins un caractère numérique.";

            if (!letterRegex.Match(password).Success)
                return "Le mot de passe doit contenir au moins une lettre.";

            return null;
        }
    }
}
