using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class PartStatsDto
    {
    public int Part { get; set; }
    public int TotalOrders { get; set; }
    public int TotalQuantity { get; set; }
        
    }
}