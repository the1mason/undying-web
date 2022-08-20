using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UndyingWorld.Web.Api.Jwt;
using UndyingWorld.Web.Models;
using UndyingWorld.Web.Services.Data;

namespace UndyingWorld.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtManagerRepository _jwtManager;
        private readonly IPlayerService _playerService;

        public AuthController(IJwtManagerRepository jwtManager, IPlayerService playerService)
        {
            _jwtManager = jwtManager;
            _playerService = playerService;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<JwtToken> Post(User user)
        {
            if (!_playerService.HasUserPermission(user.Nickname, Services.Impl.Constants.CabinetPermissions.CabinetUse))
                return StatusCode(403, new ErrorMessage($"Недостаточно прав на использование ЛК. Используйте /cabinet в игре для получения доступа."));

            var token = _jwtManager.Authenticate(user);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
