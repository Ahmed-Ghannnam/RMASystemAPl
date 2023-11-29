using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace RMASystem.DAL
{
    public class RMAContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<RetailCustomers> RetailCustomers { get; set; }
        public DbSet<APIReceivedRequests> APIReceivedRequests { get; set; }
       // public DbSet<RetailCustomerLoyaltyPointsDto> YourDTOClass { get; set; }
        public RMAContext(DbContextOptions<RMAContext> options)
            :base(options)
        {           

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // To change the table names in DB
            builder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

        }
    }
}
