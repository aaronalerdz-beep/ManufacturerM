using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Machine : BaseEntity
{
    [MaxLength(50)]
    public required string Name_machine { get; set; }
    
    [MaxLength(50)]
    public string? area { get; set; }

    public ICollection<Machine_config>? MachineConfigs { get; set; }
    
}
