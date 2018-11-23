using System.ComponentModel.DataAnnotations;

namespace FurryPal.Web.ViewModels.Categories
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can only contain up to 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "The description can only contain up to 150 characters.")]
        [Display(Name = "Short Description")]
        public string Description { get; set; }
    }
}