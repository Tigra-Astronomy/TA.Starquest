using System.ComponentModel.DataAnnotations;

namespace MS.Gamification.ViewModels.CustomValidation
    {
    public class ImageIdentifierAttribute : RegularExpressionAttribute
        {
        public ImageIdentifierAttribute() : base(@"^[A-Za-z0-9\-]*$") {}
        }
    }