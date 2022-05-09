using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculIDWeb.Models
{
    public class Equation
    {
        [Required]
        public double A { get; set; }
        [Required]
        public double B { get; set; }
        [Required]
        public double C { get; set; }
    }
}
