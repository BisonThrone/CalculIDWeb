using BL.Enum;
using BL.Interfaces;
using CalculIDWeb.Mapper;
using CalculIDWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculIDWeb.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalculationService _calculationService;

        public CalcController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<EquationResult> Index(Equation equation)
        {
            if(equation.A == 0)
            {
                return new EquationResult()
                {
                    Message = "A не может быть равен нулю"
                };
            }

            var result = _calculationService.CalculateEquation(equation.ToBLModel());

            var equationResult = new EquationResult()
            {
                X1 = result.SquareEquationResult.X1,
                X2 = result.SquareEquationResult.X2
            };

            equationResult.Message = result.SquareEquationResult.EquationSolutions switch
            {
                EquationSolutions.OneSolution => "Уравнение имеет один корень",
                EquationSolutions.TwoSolutions => "Уравнение имеет два корня",
                _ => "Уравнение не имеет корней",
            };

            return equationResult;
        }
    }
}
