//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Security.Cryptography;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using System.Web.Http.ModelBinding;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.Owin;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.OAuth;
//using RMAAPI.Models;
//using RMASystem.APIs.Providers;
//using RMAAPI.Results;
//using RMASystem.APIs.Models;
//using RMASystem.APIs.Repos;
//using RMASystem.APIs.Data.Classes;
//using RMASystem.APIs.Data;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace RMASystem.APIs.Controllers
//{
//    [Authorize]
//    [Route("api/Account")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private const string LocalLoginProvider = "Local";
//        private ApplicationUserManager _userManager;

//        public AccountController()
//        {
//        }

//        public AccountController(ApplicationUserManager userManager,
//            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
//        {
//            UserManager = userManager;
//            AccessTokenFormat = accessTokenFormat;
//        }

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

//        //// GET api/Account/UserInfo
//        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
//        //[Route("UserInfo")]
//        //public UserInfoViewModel GetUserInfo()
//        //{
//        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

//        //    return new UserInfoViewModel
//        //    {
//        //        Email = User.Identity.GetUserName(),
//        //        HasRegistered = externalLogin == null,
//        //        LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
//        //    };
//        //}

//        // POST api/Account/Logout
//        [Route("Logout")]
//        public IHttpActionResult Logout()
//        {
//            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
//            return Ok();
//        }

//        //// GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
//        //[Route("ManageInfo")]
//        //public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
//        //{
//        //    IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

//        //    if (user == null)
//        //    {
//        //        return null;
//        //    }

//        //    List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

//        //    foreach (IdentityUserLogin linkedAccount in user.Logins)
//        //    {
//        //        logins.Add(new UserLoginInfoViewModel
//        //        {
//        //            LoginProvider = linkedAccount.LoginProvider,
//        //            ProviderKey = linkedAccount.ProviderKey
//        //        });
//        //    }

//        //    if (user.PasswordHash != null)
//        //    {
//        //        logins.Add(new UserLoginInfoViewModel
//        //        {
//        //            LoginProvider = LocalLoginProvider,
//        //            ProviderKey = user.UserName,
//        //        });
//        //    }

//        //    return new ManageInfoViewModel
//        //    {
//        //        LocalLoginProvider = LocalLoginProvider,
//        //        Email = user.UserName,
//        //        Logins = logins,
//        //        ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
//        //    };
//        //}

//        // POST api/Account/ChangePassword
//        [Route("ChangePassword")]
//        public async Task<IActionResult> ChangePassword(ChangePasswordBindingModel model)
//        {
//            APIReceivedRequests apiRequest = (APIReceivedRequests)HttpContext.Items["API_REQUEST_LOG"];
//            apiRequest.USER_NAME = User.Identity.Name;
//            apiRequest.UpdateAPI_RECEIVED_REQUEST();

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
//                model.NewPassword);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            return Ok();
//        }

//        //// POST api/Account/SetPassword
//        //[Route("SetPassword")]
//        //public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

//        //    if (!result.Succeeded)
//        //    {
//        //        return GetErrorResult(result);
//        //    }

//        //    return Ok();
//        //}

//        //// POST api/Account/AddExternalLogin
//        //[Route("AddExternalLogin")]
//        //public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

//        //    AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

//        //    if (ticket == null || ticket.Identity == null || (ticket.Properties != null
//        //        && ticket.Properties.ExpiresUtc.HasValue
//        //        && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
//        //    {
//        //        return BadRequest("External login failure.");
//        //    }

//        //    ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

//        //    if (externalData == null)
//        //    {
//        //        return BadRequest("The external login is already associated with an account.");
//        //    }

//        //    IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
//        //        new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

//        //    if (!result.Succeeded)
//        //    {
//        //        return GetErrorResult(result);
//        //    }

//        //    return Ok();
//        //}

//        //// POST api/Account/RemoveLogin
//        //[Route("RemoveLogin")]
//        //public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    IdentityResult result;

//        //    if (model.LoginProvider == LocalLoginProvider)
//        //    {
//        //        result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
//        //    }
//        //    else
//        //    {
//        //        result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
//        //            new UserLoginInfo(model.LoginProvider, model.ProviderKey));
//        //    }

//        //    if (!result.Succeeded)
//        //    {
//        //        return GetErrorResult(result);
//        //    }

//        //    return Ok();
//        //}

//        //// GET api/Account/ExternalLogin
//        //[OverrideAuthentication]
//        //[HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
//        //[AllowAnonymous]
//        //[Route("ExternalLogin", Name = "ExternalLogin")]
//        //public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
//        //{
//        //    if (error != null)
//        //    {
//        //        return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
//        //    }

//        //    if (!User.Identity.IsAuthenticated)
//        //    {
//        //        return new ChallengeResult(provider, this);
//        //    }

//        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

//        //    if (externalLogin == null)
//        //    {
//        //        return InternalServerError();
//        //    }

//        //    if (externalLogin.LoginProvider != provider)
//        //    {
//        //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
//        //        return new ChallengeResult(provider, this);
//        //    }

//        //    ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
//        //        externalLogin.ProviderKey));

//        //    bool hasRegistered = user != null;

//        //    if (hasRegistered)
//        //    {
//        //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

//        //         ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
//        //            OAuthDefaults.AuthenticationType);
//        //        ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
//        //            CookieAuthenticationDefaults.AuthenticationType);

//        //        AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
//        //        Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
//        //    }
//        //    else
//        //    {
//        //        IEnumerable<Claim> claims = externalLogin.GetClaims();
//        //        ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
//        //        Authentication.SignIn(identity);
//        //    }

//        //    return Ok();
//        //}

//        //// GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
//        //[AllowAnonymous]
//        //[Route("ExternalLogins")]
//        //public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
//        //{
//        //    IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
//        //    List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

//        //    string state;

//        //    if (generateState)
//        //    {
//        //        const int strengthInBits = 256;
//        //        state = RandomOAuthStateGenerator.Generate(strengthInBits);
//        //    }
//        //    else
//        //    {
//        //        state = null;
//        //    }

//        //    foreach (AuthenticationDescription description in descriptions)
//        //    {
//        //        ExternalLoginViewModel login = new ExternalLoginViewModel
//        //        {
//        //            Name = description.Caption,
//        //            Url = Url.Route("ExternalLogin", new
//        //            {
//        //                provider = description.AuthenticationType,
//        //                response_type = "token",
//        //                client_id = Startup.PublicClientId,
//        //                redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
//        //                state = state
//        //            }),
//        //            State = state
//        //        };
//        //        logins.Add(login);
//        //    }

//        //    return logins;
//        //}

//        // POST api/Account/Register
//        [AllowAnonymous]
//        [Route("Register")]
//        public async Task<IActionResult> Register(RegisterBindingModel model)
//        {
//            APIReceivedRequests apiRequest = (APIReceivedRequests)HttpContext.Items["API_REQUEST_LOG"];
//            //apiRequest.USER_NAME = User.Identity.Name;
//            apiRequest.UpdateAPI_RECEIVED_REQUEST();

//            if (!SecurityUsers.CheckUserExistanceAndPermission(User.Identity.Name, "Register user"))
//                return Unauthorized();

//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (!SecurityUsers.CheckIfPasswordUnique(model.Password, model.UserName))
//            {
//                return BadRequest("Password is not unique");
//            }

//            SecurityRoles role = new SecurityRoles(model.Role);
//            if (role.ID.IsNull() || role.ID == 0)
//            {
//                return BadRequest("Role does not exist");
//            }

//            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };

//            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

//            if (!result.Succeeded)
//            {
//                return GetErrorResult(result);
//            }

//            SecurityUsers securityUserNew = new SecurityUsers(model.UserName);
//            securityUserNew.RoleID = role.ID;
//            securityUserNew.USER_NAME = model.UserName;
//            securityUserNew.USER_STATUS = true;
//            securityUserNew.PASS_WORD = model.Password;
//            securityUserNew.login_id = model.Password;
//            securityUserNew.mgr_flag = false;
//            securityUserNew.LANG = "Eng";
//            securityUserNew.AccessType = 0;
//            if (securityUserNew.USER_CODE.IsNotNull())
//            {
//                securityUserNew.UpdateSecurityUsers();
//            }
//            else
//            {
//                securityUserNew.USER_CODE = model.UserName;
//                securityUserNew.InsertSecurityUsers();
//            }

//            return Ok();
//        }

//        //// POST api/Account/RegisterExternal
//        //[OverrideAuthentication]
//        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
//        //[Route("RegisterExternal")]
//        //public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    var info = await Authentication.GetExternalLoginInfoAsync();
//        //    if (info == null)
//        //    {
//        //        return InternalServerError();
//        //    }

//        //    var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

//        //    IdentityResult result = await UserManager.CreateAsync(user);
//        //    if (!result.Succeeded)
//        //    {
//        //        return GetErrorResult(result);
//        //    }

//        //    result = await UserManager.AddLoginAsync(user.Id, info.Login);
//        //    if (!result.Succeeded)
//        //    {
//        //        return GetErrorResult(result); 
//        //    }
//        //    return Ok();
//        //}

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && _userManager != null)
//            {
//                _userManager.Dispose();
//                _userManager = null;
//            }

//            base.Dispose(disposing);
//        }

//        #region Helpers

//        private IAuthenticationManager Authentication
//        {
//            get { return Request.GetOwinContext().Authentication; }
//        }

//        private IActionResult GetErrorResult(IdentityResult result)
//        {
//            if (result == null)
//            {
//                return InternalServerError();
//            }

//            if (!result.Succeeded)
//            {
//                if (result.Errors != null)
//                {
//                    foreach (string error in result.Errors)
//                    {
//                        ModelState.AddModelError("", error);
//                    }
//                }

//                if (ModelState.IsValid)
//                {
//                    // No ModelState errors are available to send, so just return an empty BadRequest.
//                    return BadRequest();
//                }

//                return BadRequest(ModelState);
//            }

//            return null;
//        }

//        private class ExternalLoginData
//        {
//            public string LoginProvider { get; set; }
//            public string ProviderKey { get; set; }
//            public string UserName { get; set; }

//            public IList<Claim> GetClaims()
//            {
//                IList<Claim> claims = new List<Claim>();
//                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

//                if (UserName != null)
//                {
//                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
//                }

//                return claims;
//            }

//            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
//            {
//                if (identity == null)
//                {
//                    return null;
//                }

//                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

//                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
//                    || String.IsNullOrEmpty(providerKeyClaim.Value))
//                {
//                    return null;
//                }

//                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
//                {
//                    return null;
//                }

//                return new ExternalLoginData
//                {
//                    LoginProvider = providerKeyClaim.Issuer,
//                    ProviderKey = providerKeyClaim.Value,
//                    UserName = identity.FindFirstValue(ClaimTypes.Name)
//                };
//            }
//        }

//        private static class RandomOAuthStateGenerator
//        {
//            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

//            public static string Generate(int strengthInBits)
//            {
//                const int bitsPerByte = 8;

//                if (strengthInBits % bitsPerByte != 0)
//                {
//                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
//                }

//                int strengthInBytes = strengthInBits / bitsPerByte;

//                byte[] data = new byte[strengthInBytes];
//                _random.GetBytes(data);
//                return HttpServerUtility.UrlTokenEncode(data);
//            }
//        }

//        #endregion
//    }
//}
