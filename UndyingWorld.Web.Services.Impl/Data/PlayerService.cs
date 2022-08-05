using Microsoft.EntityFrameworkCore;
using UndyingWorld.Data;
using UndyingWorld.Web.Models;
using UndyingWorld.Web.Services.Data;

namespace UndyingWorld.Web.Services.Impl.Data
{
    public class PlayerService : IPlayerService
    {
        private IDbContextFactory<MainContext> _dbContextFactory;
        public PlayerService(IDbContextFactory<MainContext> myDbContextFactory)
        {
            _dbContextFactory = myDbContextFactory;
        }
        
        public bool IsPlayer(string username)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Authmes.Any(x => x.Realname == username);
            }
        }

        public Player GetPlayer(string username)
        {
            if (!IsPlayer(username))
                return null;
            
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var authme = context.Authmes.Where(x => x.Realname == username).Select(x => new { x.Realname, x.IsLogged, x.Lastlogin, x.Regdate }).FirstOrDefault();
                string primaryGroup = context.LuckpermsPlayers.Where(x => x.Username == username).Select(x => x.PrimaryGroup).FirstOrDefault();
                int? gamepoints = context.GamepointsUsers.Where(x => x.Name == username).Select(x => x.Balance).FirstOrDefault();

                var player = new Player()
                {
                    Nickname = authme.Realname,
                    IsOnline = authme.IsLogged == 1 ? true : false,
                    LastLogin = authme.Lastlogin != null ? Helpers.DateConverter.NormalizeAuthmeDate(authme.Lastlogin.Value) : new DateTime(0),
                    RegDate = Helpers.DateConverter.NormalizeAuthmeDate(authme.Regdate),
                    PrimaryGroup = primaryGroup ?? "default"
                };
                
                if(gamepoints != null)
                {
                    player.Balance = gamepoints.HasValue ? gamepoints.Value : 0;
                }
                return player;
            }
        }

        public bool IsUser(string username, string password)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = context.Authmes.FirstOrDefault(x => x.Realname == username);

                if (user == null)
                    return false;

                string[] passwordSplit = user.Password.Split('$');
                string hash = Helpers.HashHelper.GetHash(Helpers.HashHelper.GetHash(password) + passwordSplit[2]);
                if (hash == passwordSplit[3])
                    return true;

                return false;
            }
        }

        public Authme GetUser()
        {
            throw new NotImplementedException();
        }

        public bool IsUser()
        {
            throw new NotImplementedException();
        }
    }
}
