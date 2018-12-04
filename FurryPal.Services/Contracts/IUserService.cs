namespace FurryPal.Services.Contracts
{
    using System.Collections.Generic;
    using Models;
    
    public interface IUserAdminService
    {
        void PromoteUser(string userId);

        void DemoteUser(string userId);

        ICollection<User> GetAllUsers();
    }
}