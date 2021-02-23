using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using IO = System.IO;

namespace WebApiOef.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        string file = @"C:\users\annel\getal.txt";

        [HttpGet]
        public ActionResult<int> GetNumber()
        {
            List<int> numbers = new List<int>();
            if (IO.File.Exists(file))
            {
                string[] lines = IO.File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (Int32.TryParse(line, out int number))
                    {
                        numbers.Add(number);
                    }
                }
                return Ok(numbers[0]); // eerste getal teruggeven
            }
            return NotFound();
        }

        [HttpPost("number")]
        public ActionResult SaveNumber(int number) // bij wegschrijven geen if File.Exists nodig
        {
            string text = Convert.ToString(number);
            IO.File.WriteAllText(file, text);
            return Ok();
        }
        
        [HttpPost("random number")]
        public ActionResult SaveRandomNumber() // bij wegschrijven geen if File.Exists nodig
        {
            Random randomGenerator = new Random();
            string number = Convert.ToString(randomGenerator.Next(1, 10));
            IO.File.WriteAllText(file, number);
            return Ok();
        }
    }
}
