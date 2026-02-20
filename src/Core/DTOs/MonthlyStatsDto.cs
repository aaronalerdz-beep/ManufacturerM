using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class MonthlyStatsDto
    {
    [Required]
    public string Month { get; set; } = string.Empty;
    public int TotalOrders { get; set; }
    public int TotalQuantity { get; set; }
        
    }
}