using System;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data;

public class MContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Parts> Parts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PartsConfiguration).Assembly);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()!.ToLower());

            foreach(var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName(StoreObjectIdentifier.Table(entity.GetTableName()!, null))!.ToLower());
            }
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()!.ToLower());
            }

            foreach(var fk in entity.GetForeignKeys())
            {
                fk.SetConstraintName(fk.GetConstraintName()!.ToLower());
            }
            foreach(var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName()!.ToLower());
            }
        }
    }
}
