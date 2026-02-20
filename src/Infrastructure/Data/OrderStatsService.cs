using Core.DTOs;
using Core.Entities;
using Core.Interfeces;
public class OrderStatsService : IOrderStatsService
{
    private readonly IGenericRepository<Production_order> _repo;

    public OrderStatsService(IGenericRepository<Production_order> repo)
    {
        _repo = repo;
    }

    // Cambiamos T por el DTO real
    public async Task<IEnumerable<MonthlyStatsDto>> GetMonthlyStats()
    {
        var orders = await _repo.ListAllAsync();

        var stats = orders
            .GroupBy(o => o.started_time.Month)
            .Select(g => new MonthlyStatsDto
            {
                Month = g.Key.ToString(),
                TotalOrders = g.Count(),
                TotalQuantity = g.Sum(x => x.final_quantity ?? 0)
            })
            .OrderBy(x => int.Parse(x.Month))
            .ToList();

        return stats;
    }

    public async Task<IEnumerable<PartStatsDto>> GetPartStats()
    {
        var orders = await _repo.ListAllAsync();

        return orders
            .GroupBy(o => o.IdSeq) 
            .Select(g => new PartStatsDto
            {
                Part = g.Key,
                TotalOrders = g.Count(),
                TotalQuantity = g.Sum(x => x.target_quantity)
            })
            .ToList();
    }
}