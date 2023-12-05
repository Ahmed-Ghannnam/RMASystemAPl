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
        public DbSet<ReceivedRequests> APIReceivedRequests { get; set; }
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

            // Map the Entity to can use it with a context as Any Table,but without creating a table in DB
            modelBuilder.Entity<CustomerPointsReadSPDto>(e =>
            {
                e.HasNoKey(); // to prevent from create a Table in DB
                e.ToView("GetRetailCustomerLoyaltyPoints"); // Write null or the actual stored procedure name
            });

            // To change the table names in DB
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

            //  builder.UseCollation("Arabic_100_CI_AI_KS_WS")
        }
    }
}
