using Microsoft.AspNetCore.Mvc;
using Tikklok.Business;

namespace Tikklok.Controllers
{
    [Produces("application/json")]
    [Route("api/Tiklines")]
    public class TiklinesController : Controller
    {
        readonly ITiks _tikked;

        public TiklinesController(ITiks tikked)
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
            return Ok(_tikked.Get(userid));
        }
    }
}