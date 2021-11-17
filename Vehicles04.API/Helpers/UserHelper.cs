using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vehicles04.API.Data;
using Vehicles04.API.Data.Entities;
using Vehicles04.API.Models;

namespace Vehicles04.API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(UserManager<User> userManager,
                          RoleManager<IdentityRole> roleManager,
                          DataContext context,
                          SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(x => x.DocumetType)
                .Include(x => x.Vehicles)
                .ThenInclude(x => x.VehiclePhotos)
                .Include(x => x.Vehicles)
                .ThenInclude(x => x.Histories)
                .ThenInclude(x => x.Details)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _context.Users
                .Include(x => x.DocumetType)
                .Include(x => x.Vehicles)
                .ThenInclude(x => x.VehiclePhotos)
                .Include(x => x.Vehicles)
                .ThenInclude(x => x.Histories)
                .ThenInclude(x => x.Details)
                .FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            User currentUser = await GetUserAsync(user.Email);
            currentUser.LastName = user.LastName;
            currentUser.FirstName = user.FirstName;
            currentUser.DocumetType = user.DocumetType;
            currentUser.Documet = user.Documet;
            currentUser.Address = user.Address;
            currentUser.ImageId = user.ImageId;
            currentUser.PhoneNumber = user.PhoneNumber;
            return await _userManager.UpdateAsync(currentUser);
        }
    }
}
