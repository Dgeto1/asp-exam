namespace Tehnoforest.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tehnoforest.Data;
    using Tehnoforest.Data.Models;
    using Tehnoforest.Services.Data.Interfaces;
    using Tehnoforest.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly TehnoforestDbContext dbContext;
        public UserService(TehnoforestDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            List<UserViewModel> allUsers = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber
                })
                .ToListAsync();

            return allUsers;
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if(user == null)
            {
                return String.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
