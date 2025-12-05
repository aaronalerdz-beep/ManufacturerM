using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Machine_config : BaseEntity
{
    public decimal pressure { get; set; }
    public int grit { get; set; }
    public decimal cycle_duration { get; set; }
    public required string operator_name { get; set; } 

    public Machine? Machine { get; set; }
    public int MachinesIdSeq { get; set; }

    
    public ICollection<Cycle>? Cycle { get; set; }

}
