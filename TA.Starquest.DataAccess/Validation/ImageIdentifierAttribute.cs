using System.ComponentModel.DataAnnotations;

namespace TA.Starquest.DataAccess.Validation
    {
    public class ImageIdentifierAttribute : RegularExpressionAttribute
        {
        public ImageIdentifierAttribute() : base(@"^[A-Za-z0-9\-]*$") {}
        }
    }