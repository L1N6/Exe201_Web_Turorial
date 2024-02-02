using EXE201_Tutor_Web_API.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        [HttpGet]

        public IActionResult getAccount()
        {
            return Ok(new { accountId = 1 });
        }
    }
}
