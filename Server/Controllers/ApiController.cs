using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        [HttpGet("GetVersion")]
        public string GetVersion()
        {
            return "1.0";
        }
    }
}
