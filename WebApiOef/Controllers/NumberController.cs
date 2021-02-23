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
        public ActionResult<string> GetNumber()
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
                return Ok(numbers);
            }
            return NotFound();
        }

        [HttpPost("number")]
        public ActionResult SaveNumber(int number)
        {
            string text = Convert.ToString(number);
            if (IO.File.Exists(file))
            {
                IO.File.WriteAllText(file, text);
                return Ok();
            }
            return NotFound();
        }
        
        [HttpPost("random number")]
        public ActionResult SaveRandomNumber()
        {
            Random randomGenerator = new Random();
            string number = Convert.ToString(randomGenerator.Next(1, 10));
            if (IO.File.Exists(file))
            {
                IO.File.WriteAllText(file, number);
                return Ok();
            }
            return NotFound();
        }
    }
}
