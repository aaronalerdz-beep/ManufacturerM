using System;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class MachineConfigConfiguration : IEntityTypeConfiguration<Machine_config>
{
    public void Configure(EntityTypeBuilder<Machine_config> builder)
    {
        builder.Property(x => x.operator_name).IsRequired();
        builder.Property(x => x.cycle_duration).IsRequired();
        builder.HasOne(mc => mc.Machine) 
               .WithMany(m => m.MachineConfigs) 
               .HasForeignKey(mc => mc.MachinesIdSeq);
    }
}
