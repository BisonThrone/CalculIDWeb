using BL.Models;

namespace BL.Interfaces
{
    public interface ICalculationService
    {
        CalculationResult CalculateEquation(SquareEquation equation);
    }
}