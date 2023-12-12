using Microsoft.AspNetCore.Mvc;

namespace RequestService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://localhost:7186/api/response/25");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService return FAILURE");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Console.WriteLine("--> ResponseService return SUCCESS");
            return Ok();
        }
    }
}