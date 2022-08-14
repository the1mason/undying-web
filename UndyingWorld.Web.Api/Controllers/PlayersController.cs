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

        [HttpGet("search")]
        public ActionResult<List<SearchPlayer>> Get([FromQuery] string query = null, [FromQuery] int count = 25, [FromQuery] int offset = 0)
        {
            if(query.Length < 3)
                return BadRequest(new ErrorMessage("Длина поискового запроса должна быть больше 3 символов в длиу."));

            if (count < 1 || count > 50)
                return BadRequest(new ErrorMessage("Количество элементов должно быть в диапазоне между 1 и 50."));

            if (offset < 0)
                return BadRequest(new ErrorMessage("Сдвиг не может быть отрицательным."));

            var players = _playerService.SearchPlayers(query, count, offset);

            if (players == null)
                return NotFound();

            return players;
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

        [HttpGet("me")]
        public ActionResult<Player> GetMe()
        {
            string nickname = User.Identity.Name;

            if (string.IsNullOrWhiteSpace(nickname))
                return BadRequest();

            var player = _playerService.GetPlayer(nickname);

            if (player == null)
                return NotFound();

            return player;
        }

        [HttpGet("{nickname}/is-player")]
        public ActionResult<bool> IsPlayer(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                return BadRequest();

            return _playerService.IsPlayer(nickname);
        }
    }
}
