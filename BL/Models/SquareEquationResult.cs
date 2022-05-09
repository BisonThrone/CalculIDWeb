using BL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class SquareEquationResult
    {
        public double? X1 { get; set; }
        public double? X2 { get; set; }
        public EquationSolutions EquationSolutions { get; set; }
    }
}
