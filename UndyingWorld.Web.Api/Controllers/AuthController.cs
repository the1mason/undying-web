using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UndyingWorld.Web.Api.Jwt;
using UndyingWorld.Web.Api.Models;

namespace UndyingWorld.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtManagerRepository _jwtManager;

        public AuthController(IJwtManagerRepository jwtManager)
        {
            this._jwtManager = jwtManager;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(User user)
        {
            var token = _jwtManager.Authenticate(user);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
