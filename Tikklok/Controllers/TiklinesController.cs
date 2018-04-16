using Microsoft.AspNetCore.Mvc;
using Tikklok.Business;

namespace Tikklok.Controllers
{
    [Produces("application/json")]
    [Route("api/Tiklines")]
    public class TiklinesController : Controller
    {
        readonly ITikked _tikked;

        public TiklinesController(ITikked tikked)
        {
            _tikked = tikked;
        }

        [HttpGet("{userid}")]
        public IActionResult Get(string userid)
        {
            if (string.IsNullOrWhiteSpace(userid))
            {
                return BadRequest();
            }
            return Ok(_tikked.Tiks(userid));
        }
    }
}