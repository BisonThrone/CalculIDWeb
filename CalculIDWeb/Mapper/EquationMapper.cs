using BL.Models;
using CalculIDWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculIDWeb.Mapper
{
    public static class EquationMapper
    {
        public static SquareEquation ToBLModel(this Equation equation)
        {
            return new SquareEquation
            {
                A = equation.A,
                B = equation.B,
                C = equation.C
            };
        }
    }
}
