using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MachineDto
    {
        [Required]
        public required string machineName { get; set; }     
        public string? area { get; set; }
        
    }
}