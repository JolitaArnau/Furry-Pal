using System.ComponentModel.DataAnnotations;

namespace FurryPal.Web.Areas.Admin.ViewModels.Manufacturers
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can only contain up to 50 characters.")]
        [Display(Name = "Manufacturer Company Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(\+)(\d+)$", ErrorMessage =
            "Phone numbers should start with a plus(+), followed by the country's code and then phone number, without the leading zero(0). Should not include white spaces. e.g.: +49123456789.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}