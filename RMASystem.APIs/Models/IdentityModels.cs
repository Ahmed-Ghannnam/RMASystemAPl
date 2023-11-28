//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
////using Microsoft.AspNetCore.Identity.OwinCore;

//namespace RMASystem.APIs.Models;

//    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
//    public class ApplicationUser : IdentityUser
//    {
//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            //var userIdentity = await manager.CreateAsync(this, authenticationType);
//            var userIdentity = new ClaimsIdentity(authenticationType);

//            // Add claims as needed
//            userIdentity.AddClaim(new Claim(ClaimTypes.Name, UserName));
//            userIdentity.AddClaim(new Claim(ClaimTypes.Email, Email));

//            // Add custom user claims here
//            return userIdentity;
//        }
//    }

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public static ApplicationDbContext Create(DbContextOptions<ApplicationDbContext> options)
//        {
//            return new ApplicationDbContext(options);
//        }
//    }

