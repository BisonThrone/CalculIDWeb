using BL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CalculationResult
    {
        public SquareEquationResult SquareEquationResult { get; set; }
        public bool IsSuccess { get; set; }
    }
}
