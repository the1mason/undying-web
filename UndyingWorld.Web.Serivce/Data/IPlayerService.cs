using UndyingWorld.Data;
using UndyingWorld.Web.Models;

namespace UndyingWorld.Web.Services.Data
{
    public interface IPlayerService
    {
        public Player GetPlayer(string username);

        public bool IsUser(string username, string password);
    }
    
}
