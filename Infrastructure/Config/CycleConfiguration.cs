using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class CycleConfiguration : IEntityTypeConfiguration<Cycle>
{
    public void Configure(EntityTypeBuilder<Cycle> builder)
    {
        builder.Property(x => x.parts_per_cycle).IsRequired();
        builder.HasOne(mc => mc.MachineConfig) 
               .WithMany(m => m.Cycle) 
               .HasForeignKey(mc => mc.MachineConfIdSeq);
        builder.HasOne(mc => mc.ProductionOrder) 
               .WithMany(m => m.Cycle) 
               .HasForeignKey(mc => mc.ProductionOrderIdSeq);
    }
}
