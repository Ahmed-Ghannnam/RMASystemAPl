//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using RMASystem.BL;
//using RMASystem.DAL;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace RMASystem.APIs
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;
//        private readonly UserManager<ApplicationUser> _userManager;

//        public UsersController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
//        {
//            _userManager = userManager;
//            _configuration = configuration;
//        }

//        #region Register

//        [HttpPost]
//        [Route("register")]
//        public async Task<ActionResult> Register(RegisterDto registrDto)
//        {
//            // create user
//            var newUser = new ApplicationUser
//            {
//                UserName = registrDto.UserName,
//                Email = registrDto.Email,
//            };

//            var result = await _userManager.CreateAsync(newUser, registrDto.Password);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }
//            // create claims
//            var claims = new List<Claim>
//            {
//            // put Id of user after created in NameIdentifier prop to return user again by FindByNameAsync Method
//            new Claim(ClaimTypes.NameIdentifier, newUser.Id),
//            new Claim(ClaimTypes.Name, registrDto.UserName),
//            new Claim(ClaimTypes.Role, "User")
//            };

//            var claimResult = await _userManager.AddClaimsAsync(newUser, claims);
//            if (!claimResult.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return NoContent();
//        }

//        #endregion

//        #region Login

//        [HttpPost]
//        [Route("Login")]
//        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
//        {

//            // you must put Id in NameIdentifier to can get user with FindByNameAsync method in Register action
//            ApplicationUser? user = await _userManager.FindByNameAsync(credentials.UserName);
//            if (user is null)
//            {
//                return BadRequest();
//            }


//            //bool isLocked = await _userManager.IsLockedOutAsync(user);
//            //if (isLocked)
//            //{
//            //    return BadRequest(new GeneralResponse { Message = "Locked" });
//            //}

//            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);
//            if (!isAuthenticated)
//            {
//                //await _userManager.AccessFailedAsync(user); //Failed Attempt
//                return BadRequest();
//            }

//            var claimsList = await _userManager.GetClaimsAsync(user);

//            //verified Login so Generate Token

//            //Getting the key ready
//            string keyString = _configuration.GetValue<string>("SecretKey")!;
//            byte[] keyInBytes = Encoding.ASCII.GetBytes(keyString);
//            var key = new SymmetricSecurityKey(keyInBytes);

//            //Combine Secret Key with Hashing Algorithm
//            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

//            //Putting All together
//            var expiry = DateTime.Now.AddMinutes(15);
//            var jwt = new JwtSecurityToken(
//                expires: expiry,
//                claims: claimsList,
//                signingCredentials: signingCredentials);

//            //Getting Token String
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var tokenString = tokenHandler.WriteToken(jwt);

//            return new TokenDto
//            {
//                Token = tokenString,
//                Expiry = expiry
//            };
//        }

//        #endregion


//        #region ChangePassword

//        [Authorize]
//        [HttpPost]
//        [Route("changePassword")]
//        public async Task<ActionResult> ChangePassword(ChangePasswordDto changepasswordDto)
//        {

//            ApplicationUser? user = await _userManager.GetUserAsync(User);
//            if (user is null)
//            {
//                return BadRequest();
//            }

//            var result = await _userManager.ChangePasswordAsync(user, changepasswordDto.OldPassword, changepasswordDto.NewPassword);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return Ok("Password Changed Successfully");
//        }

//        #endregion

//        #region RequestPasswordReset

//        [Authorize]
//        [HttpPost]
//        [Route("RequestPasswordReset")]
//        public async Task<ActionResult> RequestPasswordReset()
//        {


//            ApplicationUser? user = await _userManager.GetUserAsync(User);
//            if (user is null)
//            {
//                return BadRequest();
//            }

//            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

//            // Send the reset token to the user's email

//            return Ok(new GeneralResponse { Message = token });
//        }

//        #endregion

//        #region ResetPassword

//        [Authorize]
//        [HttpPost]
//        [Route("ResetPassword")]
//        public async Task<ActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
//        {


//            ApplicationUser? user = await _userManager.GetUserAsync(User);
//            if (user is null)
//            {
//                return BadRequest();
//            }

//            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return Ok("Password Reset Successfully");
//        }

//        #endregion





//    }
//}
