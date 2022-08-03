using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndyingWorld.Data;

namespace UndyingWorld.Web.Services.Data
{
    public interface IPlayerService
    {
        public Authme GetUser(string username);
        public bool IsUser(string username, string password);
    }
}
