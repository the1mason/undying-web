using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndyingWorld.Web.Models
{
    public class ErrorMessage
    {
        public string Message { get; set; }
        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
