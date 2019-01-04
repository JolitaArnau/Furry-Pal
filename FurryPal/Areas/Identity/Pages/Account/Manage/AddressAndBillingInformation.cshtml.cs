using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FurryPal.Data;
using FurryPal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FurryPal.Web.Areas.Identity.Pages.Account.Manage
{
    public class AddressAndBillingInformationModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;
        private readonly FurryPalDbContext _dbContext;

        public AddressAndBillingInformationModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<ChangePasswordModel> logger,
            FurryPalDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this._dbContext = dbContext;
        }

        [BindProperty] public InputModel Input { get; set; }

        [TempData] public string StatusMessage { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Display(Name = "Country")]
            [StringLength(50)]
            public string CountryName { get; set; }

            [Display(Name = "City")]
            [StringLength(50)]
            public string CityName { get; set; }

            [Display(Name = "Zip Code")]
            [StringLength(10)]
            public string ZipCode { get; set; }

            [Display(Name = "Street")]
            [StringLength(50)]
            public string StreetName { get; set; }

            [Range(1, Int32.MaxValue)]
            [Display(Name = "House Number")]
            public int HouseNumber { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userAddressId = user.AddressId;

            var userAddress = _dbContext.Addresses.FirstOrDefault(id => id.Id.Equals(userAddressId));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userAddress != null)
            {
                userAddress.CountryName = Input.CountryName;
                userAddress.CityName = Input.CityName;
                userAddress.ZipCode = Input.ZipCode;
                userAddress.StreetName = Input.StreetName;
                userAddress.HouseNumber = Input.HouseNumber;

                user.Address = userAddress;
                
                _dbContext.SaveChanges();
            }

            await _userManager.UpdateAsync(user);

            _logger.LogInformation("User changed their address and billing information successfully.");
            StatusMessage = "Your profile has been updated successfully.";

            return RedirectToPage();
        }
    }
}