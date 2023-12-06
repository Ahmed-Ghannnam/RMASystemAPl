using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RMASystem.APIs;
using RMASystem.DAL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.BL
{
    public class UserAuthManger : IUserAuthManger
    {
        private readonly IUserAuthRepo _UserAuthRepo;
        private readonly IConfiguration _configuration;



        public UserAuthManger(IUserAuthRepo userAuthRepo, IConfiguration configuration)
        {
            _UserAuthRepo = userAuthRepo;
            _configuration = configuration;
        }
        public async Task<IdentityResult> Register(RegisterDto registrDto)
        {
            // create user
            var newUser = new ApplicationUser
            {
                UserName = registrDto.UserName,
                Email = registrDto.Email,
            };

            var result = await _UserAuthRepo.CreateAsync(newUser, registrDto.Password);
            if (!result.Succeeded)
            {
                return result;
            } 

            // create claims
            var claims = new List<Claim>
            {
            // put Id of user after created in NameIdentifier prop to can return user again by FindByNameAsync Method
            new Claim(ClaimTypes.NameIdentifier, newUser.Id),
            new Claim(ClaimTypes.Name, registrDto.UserName),
            new Claim(ClaimTypes.Role, "User")
            };

            var claimResult = await _UserAuthRepo.AddClaimsAsync(newUser, claims);
            if (!claimResult.Succeeded)
            {
                return claimResult;
            }

            return result;
        }

        public async Task<ActionResult<TokenDto>?> Login(LoginDto credentials)
        {
            // you must put Id in NameIdentifier to can get user with FindByNameAsync method in Register action
            ApplicationUser? user = await _UserAuthRepo.FindByNameAsync(credentials.UserName);
            if (user is null)
            {
                return null;
            }


            //bool isLocked = await _userManager.IsLockedOutAsync(user);
            //if (isLocked)
            //{
            //    return null;
            //}

            bool isAuthenticated = await _UserAuthRepo.CheckPasswordAsync(user, credentials.Password);
            if (!isAuthenticated)
            {
                //await _userManager.AccessFailedAsync(user); //Failed Attempt
                return null;
            }

            var claimsList = await _UserAuthRepo.GetClaimsAsync(user);

            //verified Login so Generate Token

            //Getting the key ready
            string keyString = _configuration.GetSection("SecretKey").Value!;
            byte[] keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);

            //Combine Secret Key with Hashing Algorithm
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //Putting All together
            var expiry = DateTime.Now.AddMinutes(30);
            var jwt = new JwtSecurityToken(
                expires: expiry,
                claims: claimsList,
                signingCredentials: signingCredentials);

            //Getting Token String
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return new TokenDto
            {
                Token = tokenString,
                Expiry = expiry
            };
        } 
      
        public async Task<IdentityResult?> ChangePasswordAsync(ClaimsPrincipal user, ChangePasswordDto changePasswordDto)
        {
            ApplicationUser? userFromDB = await _UserAuthRepo.GetUserAsync(user);
            if (userFromDB is null)
            {
                return null;
            }

            var result = await _UserAuthRepo.ChangePasswordAsync(userFromDB, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                return result;
            }
            return result;
           
        }

        public async Task<string?> GeneratePasswordResetTokenAsync(ClaimsPrincipal user)
        {

            ApplicationUser? userFromDB = await _UserAuthRepo.GetUserAsync(user);
            if (userFromDB is null)
            {
                return null;
            }
            return await _UserAuthRepo.GeneratePasswordResetTokenAsync(userFromDB);
        }

        public async Task<IdentityResult?> ResetPasswordAsync(ClaimsPrincipal user, ResetPasswordDto resetPasswordDto)
        {
            ApplicationUser? userFromDB = await _UserAuthRepo.GetUserAsync(user);
            if (userFromDB is null)
            {
                return null;
            }
            return await _UserAuthRepo.ResetPasswordAsync(userFromDB, resetPasswordDto.Token, resetPasswordDto.NewPassword);
        }
    }
}
