using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AtomicSeller.Helpers.Validation
{
    public class JpegImageType : ValidationAttribute
    {
        private const string JpegMimeType = "image/jpeg";

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var contentType = ((HttpPostedFileBase) value).ContentType;

            return contentType == JpegMimeType;
        }
    }
}
