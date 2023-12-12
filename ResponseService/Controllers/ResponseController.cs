using Microsoft.AspNetCore.Mvc;

namespace ResponseService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        [Route("{id:int}")]
        [HttpGet]
        public ActionResult GetAResult(int id)
        {
            Random rnd = new Random();
            var rndInteger = rnd.Next(0, 100);

            if (rndInteger >= id)
            {
                Console.WriteLine("--> Failure - Generate a HTTP 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                Console.WriteLine("--> Success - Generate a HTTP 200");
                return Ok();
            }
        }
    }
}