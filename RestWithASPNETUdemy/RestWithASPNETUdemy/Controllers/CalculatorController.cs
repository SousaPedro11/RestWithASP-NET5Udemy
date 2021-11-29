using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(subtraction.ToString());
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(multiplication.ToString());
        }

        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            if (ConvertToDecimal(secondNumber) == 0) return BadRequest("Divisor must be different than zero!");
            var divide = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(divide.ToString());
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber)) return BadRequest("Invalid Input");
            var multiplication = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(multiplication.ToString());
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            return decimal.TryParse(strNumber, out var decimalValue) ? decimalValue : 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            var isNumber = double.TryParse(
                strNumber,
                NumberStyles.Any,
                NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
    }
}