using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMASystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL
{
    public partial class RetailCustomersConfiguration : IEntityTypeConfiguration<RetailCustomers>
    {
        public void Configure(EntityTypeBuilder<RetailCustomers> entity)
        {
            entity.ToTable(tb => tb.HasTrigger("TRI_NewRetailCustomer"));

            entity.Property(e => e.Apartment).HasMaxLength(10);
            entity.Property(e => e.ApplyDiscount).HasDefaultValueSql("((1))");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Building).HasMaxLength(10);
            entity.Property(e => e.CardCode2).HasMaxLength(50);
            entity.Property(e => e.CardCodeExpiry).HasColumnType("date");
            entity.Property(e => e.CreditPoints).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CurrentPointsBalance).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CustomerImage).HasColumnType("image");
            entity.Property(e => e.DebitPoints).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GENDER)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InsertUID)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("InsertUID");
            entity.Property(e => e.LastSalesAmount).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LastSalesDate).HasColumnType("datetime");
            entity.Property(e => e.NationalityID).HasColumnName("NationalityID");
            entity.Property(e => e.OpeningBalancePoints).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.Phone3).HasMaxLength(20);
            entity.Property(e => e.Phone4).HasMaxLength(20);
            entity.Property(e => e.Phone5).HasMaxLength(20);
            entity.Property(e => e.SalesVolume).HasColumnType("decimal(18, 3)");

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<RetailCustomers> entity);
    }
}
