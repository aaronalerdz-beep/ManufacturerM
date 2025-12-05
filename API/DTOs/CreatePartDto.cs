using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreatePartDto
{

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Material { get; set; } = string.Empty;

    [Required]
    public string Sequence { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Must be greater than 0")]
    public decimal Weight { get; set; }

}
