using LR3.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LR3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly CalcService _calcService;
        private readonly Random _random;

        public CalcController(CalcService calcService) 
        {
            _calcService = calcService;
            _random = new Random();
        }

        private (int, int) GenerateRandomNumbers()
        {
            int a = _random.Next(1, 101); 
            int b = _random.Next(1, 101);
            return (a, b);
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            var numbers = GenerateRandomNumbers(); 
            return Ok($"Random numbers: {numbers.Item1} + {numbers.Item2} = {_calcService.Add(numbers.Item1, numbers.Item2)}");
        }


        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            var numbers = GenerateRandomNumbers();
            return Ok($"Random numbers: {numbers.Item1} - {numbers.Item2} = {_calcService.Subtract(numbers.Item1, numbers.Item2)}");
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        { 
            var numbers = GenerateRandomNumbers();
            return Ok($"Random numbers: {numbers.Item1} * {numbers.Item2} = {_calcService.Multiply(numbers.Item1, numbers.Item2)}");
        }

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b)
        {
            var numbers = GenerateRandomNumbers();
            try
            {
                return Ok($"Random numbers: {numbers.Item1} / {numbers.Item2} = {_calcService.Divide(numbers.Item1, numbers.Item2)}");
            }
            catch (DivideByZeroException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
