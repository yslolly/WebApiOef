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
        public ActionResult<List<int>> ReplaceNumber(int a, int b)
        {
            string[] lines = IO.File.ReadAllLines(file);
            List<int> numbers = new List<int>();

            foreach (string line in lines)
            {
                if (Int32.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }
            numbers[a] = b;
            return Ok(numbers);
        }

        [HttpDelete("delete on specific index")]
        public ActionResult DeleteSpecific(int index)
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
