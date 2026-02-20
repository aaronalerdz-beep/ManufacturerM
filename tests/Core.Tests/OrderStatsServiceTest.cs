using Xunit;
using FluentAssertions;
using System.Linq;
using Core.Entities;
using Moq;
using Core.Interfeces;
using Core.Services;

public class OrderStatsServiceTest
{
    [Fact]
    public async Task GetMonthlyStats_GroupforMonthCorrect()
    {
        var falseOrders = new List<Production_order>
        {
            new() { started_time = new DateTime(2026, 1, 10), target_quantity = 100 },
            new() { started_time = new DateTime(2026, 1, 20), target_quantity = 50 },
            new() { started_time = new DateTime(2026, 2, 05), target_quantity = 200 }
        };

        var mockRepo = new Mock<IGenericRepository<Production_order>>();
        mockRepo.Setup(r => r.ListAllAsync()).ReturnsAsync(falseOrders);

        var service = new OrderStatsService(mockRepo.Object);

        var result = await service.GetMonthlyStats();

        Assert.Equal(2, result.Count()); 
        Assert.Equal(150, result.First(x => x.Month == "1").TotalQuantity); 
    }
    [Fact]
    public async Task GetMonthlyStats_EmptyOrders_EmptyList()
    {
        var emptyOrder = new List<Production_order>();

        var mockRepo = new Mock<IGenericRepository<Production_order>>();
        
        mockRepo.Setup(r => r.ListAllAsync()).ReturnsAsync(emptyOrder);

        var service = new OrderStatsService(mockRepo.Object);

        var resultado = await service.GetMonthlyStats();

        Assert.Empty(resultado); 
    }
}
