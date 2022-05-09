using BL.Enum;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public static class SquareEquationService
    {
        public static SquareEquationResult CalculateSquareEquation(SquareEquation squareEquation)
        {
            var discriminate = CalculateDiscriminate(squareEquation);

            return discriminate.TypeDiscriminate switch
            {
                TypeDiscriminate.MoreZero => CalculateMoreZero(squareEquation, discriminate),
                TypeDiscriminate.EqualsZero => CalculateEqualsZero(squareEquation),
                _ => CalculateLessZero(squareEquation, discriminate),
            };
        }

        private static SquareEquationResult CalculateMoreZero(SquareEquation squareEquation, Discriminate discriminate)
        {
            return new SquareEquationResult
            {
                X1 = ((-squareEquation.B + Math.Sqrt(discriminate.Result)) / (2 * squareEquation.A)).ToString(),
                X2 = ((-squareEquation.B - Math.Sqrt(discriminate.Result)) / (2 * squareEquation.A)).ToString(),
                EquationSolutions = EquationSolutions.TwoSolutions
            };
        }
        private static SquareEquationResult CalculateLessZero(SquareEquation squareEquation, Discriminate discriminate)
        {
            return new SquareEquationResult
            {
                X1 = ((-squareEquation.B + Math.Sqrt(-discriminate.Result)) / (2 * squareEquation.A)).ToString() + " * i",
                X2 = ((-squareEquation.B - Math.Sqrt(-discriminate.Result)) / (2 * squareEquation.A)).ToString() + " * i",
                EquationSolutions = EquationSolutions.TwoSolutions
            };
        }
        private static SquareEquationResult CalculateEqualsZero(SquareEquation squareEquation)
        {
            return new SquareEquationResult
            {
                X1 = ((-squareEquation.B) / (2 * squareEquation.A)).ToString(),
                EquationSolutions = EquationSolutions.OneSolution
            };
        }

        private static Discriminate CalculateDiscriminate(SquareEquation squareEquation)
        {
            var result = squareEquation.B * squareEquation.B - 4 * squareEquation.A * squareEquation.C;

            var type = result switch
            {
                < 0 => TypeDiscriminate.LessZero,
                > 0 => TypeDiscriminate.MoreZero,
                _ => TypeDiscriminate.EqualsZero
            };

            return new Discriminate
            {
                Result = result,
                TypeDiscriminate = type
            };
        }
    }
}
