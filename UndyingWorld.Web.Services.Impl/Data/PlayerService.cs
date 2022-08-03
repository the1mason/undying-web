using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndyingWorld.Data;
using UndyingWorld.Web.Services;

namespace UndyingWorld.Web.Services.Impl.Data
{
    public class PlayerService : IPlayerService
    {
        private IDbContextFactory<MainContext> _myDbContextFactory;
        public PlayerService(IDbContextFactory<MainContext> myDbContextFactory)
        {
            _myDbContextFactory = myDbContextFactory;
        }
        
        public Authme GetUser(string username)
        {
            using (var context = _myDbContextFactory.CreateDbContext())
            {
                var user = context.Authmes.FirstOrDefault(x => x.Username == username);
                return user;
            }
        }

        public bool IsUser(string username, string password)
        {
            var user = GetUser(username);
            if (user == null)
                return false;
            
            string[] passwordSplit = user.Password.Split('$');
            string hash = Helpers.HashHelper.GetHash(Helpers.HashHelper.GetHash(password) + passwordSplit[2]);
            if (hash == passwordSplit[3])
                return true;

            return false;
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
