using Microsoft.AspNetCore.Mvc;

namespace DotNetMinimalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from RoomController");
        }
    }
}