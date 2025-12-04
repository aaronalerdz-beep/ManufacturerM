using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class ProductionOrderConfiguration : IEntityTypeConfiguration<Production_order>
{
    public void Configure(EntityTypeBuilder<Production_order> builder)
    {
        builder.Property(x => x.target_quantity).IsRequired();
        builder.HasOne(x => x.Part) 
               .WithMany(xs => xs.Productionorder) 
               .HasForeignKey(x => x.PartIdSeq);
    }
}
