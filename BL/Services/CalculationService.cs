using BL.Enum;
using BL.Interfaces;
using BL.Models;
using DL;
using DL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly CalcContext _calcContext;

        public CalculationService(CalcContext calcContext)
        {
            _calcContext = calcContext;
        }
        public CalculationResult CalculateEquation(SquareEquation equation)
        {
            var calculationResult = new CalculationResult();

            var resultFromDb = GetOrDefault(equation);

            if (resultFromDb != null)
            {
                return new CalculationResult
                {
                    IsSuccess = resultFromDb.EquationSolutions != EquationSolutions.NoSolutions,
                    SquareEquationResult = resultFromDb
                };
            }

            calculationResult.SquareEquationResult = SquareEquationService.CalculateSquareEquation(equation);

            calculationResult.IsSuccess =
                calculationResult.SquareEquationResult.EquationSolutions switch
                {
                    EquationSolutions.NoSolutions => false,
                    _ => true
                };

            AddResultToDb(equation, calculationResult.SquareEquationResult);

            return calculationResult;
        }

        private void AddResultToDb(SquareEquation equation, SquareEquationResult squareEquationResult)
        {
            var calcEntity = new Calc
            {
                A = equation.A,
                B = equation.B,
                C = equation.C,
                X1 = squareEquationResult.X1,
                X2 = squareEquationResult.X2
            };

            _calcContext.Calcs.Add(calcEntity);
            _calcContext.SaveChanges();
        }

        private SquareEquationResult GetOrDefault(SquareEquation equation)
        {
            var result = _calcContext.Calcs.FirstOrDefault(
                x => x.A == equation.A
                && x.B == equation.B
                && x.C == equation.C);

            if (result == null)
            {
                return null;
            }

            EquationSolutions equationSolutions;

            if (result.X1 == null) equationSolutions = EquationSolutions.NoSolutions;
            else if (result.X1 != null && result.X2 == null) equationSolutions = EquationSolutions.OneSolution;
            else equationSolutions = EquationSolutions.TwoSolutions;

            return new SquareEquationResult
            {
                X1 = result.X1,
                X2 = result.X2,
                EquationSolutions = equationSolutions,
            };
        }
    }
}
