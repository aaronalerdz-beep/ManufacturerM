using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
public class Part : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? PartNum { get; private set; }

    [MaxLength(255)]
    public required string Description { get; set; }

    [MaxLength(50)]
    public required string Material { get; set; }

    [MaxLength(500)]
    public string? Sequence { get; set; }

    public decimal Weight { get; set; }

    
    public ICollection<Production_order>? Productionorder { get; set; }
}

