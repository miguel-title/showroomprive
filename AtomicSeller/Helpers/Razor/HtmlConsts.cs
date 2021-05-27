namespace AtomicSeller.Helpers.Razor
{
    public static class HtmlConsts
    {
        public static class Dimens
        {
            public const int DefaultPageCol = 12;
            public const int DefaultPageColOffset = 0;
            public const int DefaultContentPageCol = 9;
            public const int DefaultContentPageColOffset = 1;
        }

        public static class Snippets
        {
            public const string ClearFix = "<div class=\"clearfix\"></div>";
        }

        public static class DOM
        {
            public enum H
            {
                H1, H2, H3, H4, H5, H6
            }
        }

        /**
         * Used client-side by jquery.maskedinput
         * @see https://github.com/digitalBush/jquery.maskedinput
         */
        public static class InputMasks
        {
            public const string NumCCSS = "999999/9";
            public const string SIRET = "999.999.999.99999";
        }
    }
}
