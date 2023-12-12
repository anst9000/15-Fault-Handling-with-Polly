using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            // var client = new HttpClient();
            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("https://localhost:7186/api/response/25");

            // var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //     () => client.GetAsync("https://localhost:7186/api/response/25")
            // );

            // var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(
            //     () => client.GetAsync("https://localhost:7186/api/response/25")
            // );

            // var response = await _clientPolicy.ExponentialrHttpRetry.ExecuteAsync(
            //     () => client.GetAsync("https://localhost:7186/api/response/25")
            // );

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