using FurryPal.Common;

namespace FurryPal.Services.Users
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class UserAdminService : IUserAdminService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly FurryPalDbContext context;

        public UserAdminService(SignInManager<User> signInManager, UserManager<User> userManager,
            FurryPalDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
        }

        public void PromoteUser(string userId)
        {
            var user = this.userManager.Users.FirstOrDefault(u => u.Id == userId);
            var role = this.userManager.GetRolesAsync(user).GetAwaiter().GetResult();
            var userRole = this.context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
            this.context.UserRoles.Remove(userRole);
            this.userManager.AddToRoleAsync(user, RoleConstants.Administrator).GetAwaiter().GetResult();
        }

        public void DemoteUser(string userId)
        {
            var user = this.userManager.Users.FirstOrDefault(u => u.Id == userId);
            var role = this.userManager.GetRolesAsync(user).GetAwaiter().GetResult();
            var userRole = this.context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
            this.context.UserRoles.Remove(userRole);
            this.userManager.AddToRoleAsync(user, RoleConstants.User).GetAwaiter().GetResult();
        }

        public ICollection<User> GetAllUsers()
        {
            var users = this.context
                .Users
                .ToList();
            return users;
        }
    }
}