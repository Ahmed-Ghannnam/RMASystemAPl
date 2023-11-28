using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RMASystem.APIs;
using RMASystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.BL
{
    public interface IUserAuthManger
    {
        Task<IdentityResult> Register(RegisterDto registrDto);
        Task<ActionResult<TokenDto>?> Login(LoginDto credentials);
        Task<IdentityResult?> ChangePasswordAsync(ClaimsPrincipal user, ChangePasswordDto changePasswordDto);
        Task<string?> GeneratePasswordResetTokenAsync(ClaimsPrincipal user);
        Task<IdentityResult?> ResetPasswordAsync(ClaimsPrincipal user, ResetPasswordDto resetPasswordDto);
    }
}
