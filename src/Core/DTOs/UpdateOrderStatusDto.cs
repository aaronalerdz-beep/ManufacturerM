using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class UpdateOrderStatusDto
{
    public string Status { get; set; } = string.Empty;
    public int final_quantity { get; set; } 
    public DateTime finished_time {get; set; }
}