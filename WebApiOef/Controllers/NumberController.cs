using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace WebApiOef.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        string file = @"C:\users\annel\getal.txt";

        public NumberController()
        {

        }

        [HttpGet]
        public ActionResult<string> GetNumber()
        {
            if (File.Exists(file))
            {
                string[] lines = System.IO.File.ReadAllLines(file);
                return Ok(lines);
            }
            return NotFound();
        }

        [HttpPost("number")]
        public ActionResult SaveNumber(int number)
        {
            string text = Convert.ToString(number);
            if (System.IO.File.Exists(file))
            {
                System.IO.File.WriteAllText(file, text);
                return Ok();
            }
            return NotFound();
        }
        
        [HttpPost("random number")]
        public ActionResult SaveRandomNumber()
        {
            Random randomGenerator = new Random();
            string number = Convert.ToString(randomGenerator.Next(1, 10));
            if (System.IO.File.Exists(file))
            {
                System.IO.File.WriteAllText(file, number);
                return Ok();
            }
            return NotFound();
        }
    }
}
