using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace RMASystem.DAL
{
    public class RMAContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<RetailCustomers> RetailCustomers { get; set; }
        public DbSet<APIReceivedRequests> APIReceivedRequests { get; set; }
        public virtual DbSet<LoyaltySetupDetail> LoyaltySetupDetails { get; set; }
        public virtual DbSet<LoyaltySetupHeader> LoyaltySetupHeader { get; set; }
        public virtual DbSet<RetailCustomerPointsStatement> RetailCustomerPointsStatement { get; set; }
        public DbSet<CustomerPointsReadSPDto> CustomerPointsReadSPDtos { get; set; }

        public RMAContext(DbContextOptions<RMAContext> options)
            :base(options)
        {           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the type to the stored procedure result without creating a table
            modelBuilder.Entity<CustomerPointsReadSPDto>(e =>
            {
                e.HasNoKey();
                e.ToView("GetRetailCustomerLoyaltyPoints"); // or Replace with the actual stored procedure name
            });

            // To change the table names in DB
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

            //  builder.UseCollation("Arabic_100_CI_AI_KS_WS")
        }
    }
}
