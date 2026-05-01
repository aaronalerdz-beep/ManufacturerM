using System;
using System.Linq.Expressions;
using Core.Entities;
using Core.DTOs;


namespace Core.Interfaces;

public interface IOrderStatsService 
{
    Task<IEnumerable<MonthlyStatsDto>> GetMonthlyStats();
    Task<IEnumerable<PartStatsDto>> GetPartStats();
    Task<IEnumerable<ProductionOrderDto>> GetStatusCreated();
}
