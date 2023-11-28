using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL
{
    public class UserAuthRepo : IUserAuthRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public async Task<IdentityResult> CreateAsync(ApplicationUser newUser, string Password)
        {
            return await _userManager.CreateAsync(newUser, Password);
        }

        public async Task<IdentityResult> AddClaimsAsync(ApplicationUser newUser, IEnumerable<Claim> claims)
        {
          return await _userManager.AddClaimsAsync(newUser, claims);
        }
        public UserAuthRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser?> FindByNameAsync(string userName)
        {
             return await _userManager.FindByNameAsync(userName);
        }
        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            return await _userManager.GetClaimsAsync(user);
        }
        public async Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
           return await _userManager.CheckPasswordAsync(user, password);
        }
        public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }
   
        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
           return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

     
    }
}
