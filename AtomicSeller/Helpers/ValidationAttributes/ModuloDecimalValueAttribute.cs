using System.ComponentModel.DataAnnotations;

namespace AtomicSeller.Helpers.ValidationAttributes
{
    public class ModuloDecimalValueAttribute : ValidationAttribute
    {
        private readonly decimal modulo;
        private readonly int result;

        public ModuloDecimalValueAttribute(string modulo, int result = 0, string errorMessage=null)
        {
            this.modulo = decimal.Parse(modulo);
            this.result = result;
            ErrorMessage = errorMessage;

            // Try to guess error message
            if (result == 0 && errorMessage == null)
            {
                ErrorMessage = "La valeur doit être un multiple de " + modulo;
            }
        }

        public override bool IsValid(object value)
        {
            return (decimal) value % modulo == result;
        }
    }
}
