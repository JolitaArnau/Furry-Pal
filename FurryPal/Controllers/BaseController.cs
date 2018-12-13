namespace FurryPal.Web.Controllers
{
    using AutoMapper;
    using FurryPal.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        protected readonly UserManager<User> userManager;
        protected readonly SignInManager<User> signInManager;
        protected IMapper mapper;

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
    }
}