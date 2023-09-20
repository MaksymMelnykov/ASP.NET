using Microsoft.AspNetCore.Mvc;

namespace Lab3
{
    [Route("[controller]")]
    public class Calc_TimeOfDayController : ControllerBase
    {
        private readonly CalcService _calcService;
        private readonly TimeOfDayService _timeOfDayService;

        public Calc_TimeOfDayController(CalcService calcService, TimeOfDayService timeOfDayService)
        {
            _calcService = calcService;
            _timeOfDayService = timeOfDayService;
        }

        [HttpGet("add")]
        public IActionResult Add(double number1, double number2)
        {
            double add = _calcService.Add(number1, number2);
            return Ok($"Result of add: {add}");
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(double number1, double number2)
        {
            double subtract = _calcService.Subtract(number1, number2);
            return Ok($"Result of subtract: {subtract}");
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(double number1, double number2)
        {
            double multiply = _calcService.Multiply(number1, number2);
            return Ok($"Result of multiply: {multiply}");
        }

        [HttpGet("divide")]
        public IActionResult Divide(double number1, double number2)
        {
            try
            {
                double divide = _calcService.Divide(number1, number2);
                return Ok($"Result of divide: {divide}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("timeOfDay")]
        public IActionResult GetTimeOfDay()
        {
            string timeOfDay = _timeOfDayService.GetTimeOfDay();
            return Ok($"Зараз: {timeOfDay}");
        }
    }
}
