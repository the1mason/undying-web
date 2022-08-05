using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndyingWorld.Web.Models
{
    public class Player
    {
        public string Nickname { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsOnline { get; set; }
        public int Balance { get; set; }
        public string PrimaryGroup { get; set; }
    }
}
