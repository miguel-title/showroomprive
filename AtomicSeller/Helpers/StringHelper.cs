namespace AtomicSeller.Models
{
    public static class StringHelper
    {
        public static string GetNumSSFormate(string numSS, string cle)
        {
            if (string.IsNullOrWhiteSpace(numSS))
                return string.Empty;

            if (numSS.Length == 13)
            {
                numSS = numSS.Insert(1, ".");
                numSS = numSS.Insert(4, ".");
                numSS = numSS.Insert(7, ".");
                numSS = numSS.Insert(10, ".");
                numSS = numSS.Insert(14, ".");
                numSS += "/" + cle;
            }
            else
                numSS = numSS + "/" + cle;


            return numSS;
        }

        public static string GetNumCCSSFormate(string numSS, string cle)
        {
            if (string.IsNullOrWhiteSpace(numSS))
                return string.Empty;

                numSS = numSS + "/" + cle;

            return numSS;
        }

        public static string GetSIRENFormate(string siren)
        {
            return string.IsNullOrEmpty(siren) ? string.Empty : siren.Insert(3, " ").Insert(7, " ");
        }

        public static string GetNumTelFormate(string numTel)
        {
            if (string.IsNullOrEmpty(numTel))
                return string.Empty;

            if (numTel.Length != 10)
                return numTel;

            return numTel
                .Insert(8, " ")
                .Insert(6, " ")
                .Insert(4, " ")
                .Insert(2, " ");
        }
    }
}
