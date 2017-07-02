using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Common_Features.Models
{
    public struct User
    {
        public string Username { get; set; }
        public string Id { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
