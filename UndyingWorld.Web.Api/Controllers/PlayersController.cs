using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UndyingWorld.Web.Models;
using UndyingWorld.Web.Services.Data;
using UndyingWorld.Web.Services.Impl.Data;

namespace UndyingWorld.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
        [HttpGet("{nickname}")]
        public ActionResult<Player> Get(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                return BadRequest();
            
            var player = _playerService.GetPlayer(nickname);

            if (player == null)
                return NotFound();

            return player;
        }
    }
}
