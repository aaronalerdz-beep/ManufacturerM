using Core.DTOs;
using Core.Entities;
using Core.Interfeces;

namespace Core.Services;
public class OrderStatsService : IOrderStatsService
{
    private readonly IGenericRepository<Production_order> _repo;

    public OrderStatsService(IGenericRepository<Production_order> repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<MonthlyStatsDto>> GetMonthlyStats()
    {
        var orders = await _repo.ListAllAsync();

        var stats = orders
            .GroupBy(o => o.started_time.Month)
            .Select(g => new MonthlyStatsDto
            {
                Month = g.Key.ToString(),
                TotalOrders = g.Count(),
                TotalQuantity = g.Sum(x => x.target_quantity)
            })
            .OrderBy(x => int.Parse(x.Month))
            .ToList();

        return stats;
    }

    public async Task<IEnumerable<PartStatsDto>> GetPartStats()
    {
        var orders = await _repo.ListAllAsync();

        return orders
            .GroupBy(o => o.PartIdSeq) 
            .Select(g => new PartStatsDto
            {
                Part = g.Key,
                TotalOrders = g.Count(),
                TotalQuantity = g.Sum(x => x.target_quantity)
            })
            .ToList();
    }

    public async Task<IEnumerable<ProductionOrderDto>> GetStatusCreated()
    {
        var orders = await _repo.ListAllAsync();

        return orders
        .Where(o => o.status == "Created")
        .OrderBy(o => o.IdSeq)
        .Select(g => new ProductionOrderDto
        {
            PartId = g.PartIdSeq,
            Quantity = g.target_quantity,
            IdSeq = g.IdSeq
        }).ToList() ;
    }
}