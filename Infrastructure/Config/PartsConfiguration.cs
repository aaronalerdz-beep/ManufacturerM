using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class PartsConfiguration : IEntityTypeConfiguration<Part>
{
    

    public void Configure(EntityTypeBuilder<Part> builder)
    {
        builder.Property(x => x.Weight).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.PartNum).HasComputedColumnSql("'PN-' || lpad(\"IdSeq\"::text, 6, '0')", stored:true);
    }
}
