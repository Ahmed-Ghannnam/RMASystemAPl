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
    public partial class LoyaltySetupDetailConfiguration : IEntityTypeConfiguration<LoyaltySetupDetail>
    {
        public void Configure(EntityTypeBuilder<LoyaltySetupDetail> entity)
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BulkValue).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.FromPoint).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.HeaderId).HasColumnName("HeaderID");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUid).HasColumnName("InsertUID");
            entity.Property(e => e.ToPoint).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 3)");

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<LoyaltySetupDetail> entity);
    }
}
