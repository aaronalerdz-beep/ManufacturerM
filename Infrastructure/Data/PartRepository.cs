using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class PartRepository(MContext context) : IPartRepository
{
    public void AddParts(Parts part)
    {
        context.Parts.Add(part);
    }

    public void DeletePart(Parts part)
    {
        context.Parts.Remove(part);
    }

    public async Task<IReadOnlyList<string>> GetMaterialAsync()
    {
        return await context.Parts.Select(x => x.Material).Distinct().ToListAsync();
    }

    public async Task<IReadOnlyList<Parts>> GetPartsAsync(string? material, string? sort)
    {
        var query = context.Parts.AsQueryable();
        if(!string.IsNullOrWhiteSpace(material))
            query = query.Where(x => x.Material ==material);

        query = sort switch
        {
            "weightAsc" => query.OrderBy(x => x.Weight),
            "weightDesc" => query.OrderByDescending(x => x.Weight),
            _ => query.OrderByDescending(x => x.IdSeq)
        };   
    

        return await query.ToListAsync();
    }

    public async Task<Parts?> GEtPartsByIdAsync(int id)
    {
        return await context.Parts.FindAsync(id);
    }

    public bool PartsExist(int id)
    {
        return context.Parts.Any(x => x.IdSeq == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdatePart(Parts part)
    {
        context.Entry(part).State = EntityState.Modified;
    }
}
