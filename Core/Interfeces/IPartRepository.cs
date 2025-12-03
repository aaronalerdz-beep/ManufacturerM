using System;
using Core.Entities;

namespace Core.Interfeces;

public interface IPartRepository
{
    Task<IReadOnlyList<Parts>> GetPartsAsync(string? material, string? sort);
    Task<Parts?> GEtPartsByIdAsync(int id);
    Task<IReadOnlyList<string>> GetMaterialAsync();
    void AddParts(Parts part);
    void UpdatePart(Parts part);
    void DeletePart(Parts part);
    bool PartsExist(int id);
    Task<bool> SaveChangesAsync();

}
