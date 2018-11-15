using System.Threading.Tasks;
using FurryPal.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FurryPal.Web.Middleware
{
    public class SeederMiddleware
    {
        private readonly RequestDelegate next;

        public SeederMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext httpContext, RoleManager<IdentityRole> roleManager)
        {
            Seeder.SeedRoles(roleManager).Wait();

            return next(httpContext);
        }
    }
}
