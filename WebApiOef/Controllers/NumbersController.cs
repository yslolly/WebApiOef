using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IO = System.IO;

namespace WebApiOef.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        string file = @"C:\users\annel\getallen.txt";

        [HttpGet]
        public ActionResult<List<int>> GetNumber()
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

        [HttpPost("add number")]
        public ActionResult SaveNumber(int number)
        {
            string text = Convert.ToString(number);
            if (IO.File.Exists(file))
            {
                using StreamWriter file = new(@"C:\users\annel\getallen.txt", append: true);
                file.WriteLineAsync(text);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("delete first number")]
        public ActionResult DeleteNumber() // geen return type nodig want laatste lijn = return Ok();
        {
            string[] lines = IO.File.ReadAllLines(file);

            List<string> linesList = lines.ToList();
            linesList.Remove(linesList[0]);
            
            IO.File.WriteAllLines(file, linesList);
            return Ok(); 
        }

        [HttpPut]
        public ActionResult ReplaceNumber(int index, int newNumber) // return type nodig want laatste lijn = return Ok(lijst van integers);
        {
            string[] lines = IO.File.ReadAllLines(file);
            List<string> numbers = lines.ToList();

            numbers[index] = Convert.ToString(newNumber);
            IO.File.WriteAllLines(file, numbers);
            return Ok();
        }

        [HttpDelete("delete on specific index")]
        public ActionResult DeleteSpecific(int index) // try catch OutOfRange
        {
            string[] lines = IO.File.ReadAllLines(file);
            List<string> linesList = lines.ToList();
            if (index < linesList.Count && index >= 0)
            {
                linesList.Remove(linesList[index]);
                IO.File.WriteAllLines(file, linesList);
                return Ok();
            }
            return BadRequest();
        }
    }
}
