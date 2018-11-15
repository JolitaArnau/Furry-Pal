using System.Threading.Tasks;
using FurryPal.Common;
using Microsoft.AspNetCore.Identity;

namespace FurryPal.Web.Utilities
{
    public static class Seeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var adminRoleExists = await roleManager.RoleExistsAsync(RoleConstants.Administrator);
            if (!adminRoleExists)
            {
                var adminRole = new IdentityRole()
                {
                    Name = RoleConstants.Administrator,
                    NormalizedName = RoleConstants.Administrator.ToUpper(),
                    ConcurrencyStamp = "0"
                };
                var result = await roleManager.CreateAsync(adminRole);
            }

            var userRoleExists = await roleManager.RoleExistsAsync(RoleConstants.User);
            if (!userRoleExists)
            {
                var userRole = new IdentityRole()
                {
                    Name = RoleConstants.User, 
                    NormalizedName = RoleConstants.User.ToUpper(), 
                    ConcurrencyStamp = "1"
                };
                var result = await roleManager.CreateAsync(userRole);
            }
        }
    }
}