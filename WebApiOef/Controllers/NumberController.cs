using Microsoft.AspNetCore.Mvc;

namespace WebApiOef.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        string file = @"Desktop\getal.txt";

        [HttpGet]
        public ActionResult<int> GetNumber()
        {
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                return Ok(lines);
            }
            return NotFound();
        }

        [HttpPost("number")]


        [HttpPost("random number")]



    }
}
