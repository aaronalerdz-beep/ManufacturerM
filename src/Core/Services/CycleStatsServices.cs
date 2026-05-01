using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Core.Services;

public class CycleStatsServices : ICycleStatsServices
{
        
    private readonly IGenericRepository<Cycle> _repo;

    public CycleStatsServices(IGenericRepository<Cycle> repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<PressureStatsDto>> CyclePressureIncomplet()
    {
        var spec = new CycleWithDtoSpecification(new SpecParams()); 
        var cycles = await _repo.ListAsync(spec);

        var stats = cycles
        .GroupBy(c => c.Pressure) 
        .Select(g => new PressureStatsDto
        {
            Pressure = g.Key,
            TotalCycles = g.Count(),
            IncompleteCycles = g.Count(c => c.finished < c.parts_per_cycle),
            Efficiency = g.Any() 
                ? Math.Round((double)g.Count(c => c.finished >= c.parts_per_cycle) / g.Count() * 100, 2) 
                : 0
        })
        .OrderBy(x => x.Pressure)
        .ToList();

    return stats;
    }

}