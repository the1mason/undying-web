using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndyingWorld.Data;
using UndyingWorld.Web.Services;

namespace UndyingWorld.Web.Services.Impl.Data
{
    public interface IPlayerService
    {
        public Authme GetUser(string username);

        public bool IsUser(string username, string password);
    }
    
}
