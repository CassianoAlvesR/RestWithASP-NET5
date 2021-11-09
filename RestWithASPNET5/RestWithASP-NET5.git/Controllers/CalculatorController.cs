using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASP_NET5.git.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        //soma
        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber) {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {

                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());

            }

            return BadRequest("Invalid Input");

        }

        //multiplica
        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber){

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var multiplicacao = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiplicacao.ToString());

            }

            return BadRequest("Invalid Input");

        }

        //divisao
        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var divisao = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(divisao.ToString());

            }

            return BadRequest("Invalid Input");

        }

        //subtracao
        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                var subtracao = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(subtracao.ToString());

            }

            return BadRequest("Invalid Input");

        }
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;

        }

        private decimal ConvertToDecimal(string strNumber)
        {

            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;

        }

    }
}
