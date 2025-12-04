using System;

namespace Core.Entities;

public class Production_order : BaseEntity
{
    public int target_quantity { get; set; }
    public int final_quantity { get; set; }
    public DateTime started_time {get; set; }
    public DateTime? finished_time {get; set; }

    public Part? Part { get; set; }
    public int PartIdSeq { get; set; }

    
    public ICollection<Cycle>? Cycle { get; set; }
    
}
