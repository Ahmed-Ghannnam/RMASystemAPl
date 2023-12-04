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
    public partial class LoyaltySetupHeadersConfiguration : IEntityTypeConfiguration<LoyaltySetupHeader>
    {
        public void Configure(EntityTypeBuilder<LoyaltySetupHeader> entity)
        {
            entity.ToTable("LoyaltySetupHeader");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplyDate).HasColumnType("datetime");
            entity.Property(e => e.GiftPoints).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUid).HasColumnName("InsertUID");
            entity.Property(e => e.Minimum).HasColumnType("decimal(18, 3)");

            OnConfigurePartial(entity);
        }
        partial void OnConfigurePartial(EntityTypeBuilder<LoyaltySetupHeader> entity);
    }
}
