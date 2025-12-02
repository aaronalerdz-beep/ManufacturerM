using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;
public class Parts : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? PartNum { get; private set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? Material { get; set; }

    [MaxLength(500)]
    public string? Sequence { get; set; }

    public decimal Weight { get; set; }
}

