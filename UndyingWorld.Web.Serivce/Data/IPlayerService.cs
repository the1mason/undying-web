using UndyingWorld.Data;

namespace UndyingWorld.Web.Services.Impl.Data
{
    public interface IPlayerService
    {
        public Authme GetUser(string username);

        public bool IsUser(string username, string password);
    }
    
}
