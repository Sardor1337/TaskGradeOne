using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGrade.Application.Models
{
    public class NameContainsStudent
    {
        [Required]
        public string? Name { get; set; } = string.Empty;
    }
}
