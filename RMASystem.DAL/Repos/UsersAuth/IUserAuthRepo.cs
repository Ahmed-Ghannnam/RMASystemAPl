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
    public interface IUserAuthRepo
    {
        Task<IdentityResult> CreateAsync(ApplicationUser newUser, string Password);
        Task<IdentityResult> AddClaimsAsync(ApplicationUser newUser, IEnumerable<Claim> claims);
        Task<ApplicationUser?> FindByNameAsync(string userName);

        Task<IList<Claim>> GetClaimsAsync(ApplicationUser user);
        Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal user);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string oldPassword, string newPassword);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword);
    }
}
