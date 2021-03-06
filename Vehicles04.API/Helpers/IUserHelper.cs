using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles04.API.Data.Entities;
using Vehicles04.API.Models;

namespace Vehicles04.API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);
        
        Task<User> GetUserAsync(Guid email);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task<IdentityResult> AddUserAsync(User user, string password);
        
        Task<IdentityResult> UpdateUserAsync(User user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
