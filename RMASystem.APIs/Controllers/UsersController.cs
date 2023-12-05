using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RMASystem.BL;
using RMASystem.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RMASystem.APIs
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAuthManger _userAuthManger;

        public UsersController(IUserAuthManger userAuthManger)
        {
       ;
            _userAuthManger = userAuthManger;
        }

        #region Register

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterDto registrDto)
        {
            
            var result = await _userAuthManger.Register(registrDto);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
          
            return NoContent();
        }

        #endregion

        #region Login

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            var tokenDto = await _userAuthManger.Login(credentials);
            if(tokenDto is null) 
            {
                return BadRequest(new GeneralResponse { Message = "Invalid username or password" });
            }

            return tokenDto;   
        }

        #endregion


        #region ChangePassword

        [Authorize] 
        [HttpPost]
        [Route("changePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordDto changepasswordDto)
        {

            var result = await _userAuthManger.ChangePasswordAsync(User, changepasswordDto);
            if (result is null)
            {
                return BadRequest();
            }
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password Changed Successfully");
        }

        #endregion

        #region RequestPasswordReset
        [Authorize]
        [HttpPost("RequestPasswordReset")]
        public async Task<ActionResult> RequestPasswordReset()
        {        
            var token = await _userAuthManger.GeneratePasswordResetTokenAsync(User);
            if (token is null)
            {
                return BadRequest();
            }

            // Send the reset token to the user's email
            return Ok(new GeneralResponse { Message = token });
        }
        #endregion

        #region ResetPassword
        [Authorize]
        [HttpPost("ResetPassword")]
    //   [Route("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await _userAuthManger.ResetPasswordAsync(User, resetPasswordDto);
            if (result is null)
            {
                return BadRequest();
            }
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Password Reset Successfully");
        }
        #endregion





    }
}
