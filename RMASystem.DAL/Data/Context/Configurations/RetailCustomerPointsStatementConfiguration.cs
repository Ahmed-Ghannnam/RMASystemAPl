using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL
{
    public partial class RetailCustomerPointsStatementConfiguration : IEntityTypeConfiguration<RetailCustomerPointsStatement>
    {
        public void Configure(EntityTypeBuilder<RetailCustomerPointsStatement> entity)
        {
            entity.ToTable("RetailCustomerPointsStatement");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplyDate).HasColumnType("date");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Credit).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CusId).HasColumnName("CusID");
            entity.Property(e => e.Debit).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DocumentNo).HasMaxLength(50);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");

            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.InsertUid)
                .HasMaxLength(50)
                .HasColumnName("InsertUID");

            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.RemainingPoints).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TransDate).HasColumnType("date");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 3)");

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<RetailCustomerPointsStatement> entity);
    }
}
