using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_Common_Features.Models;

namespace SignalR_Common_Features
{
    public class Message
    {
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => $"{Sender.Username}({Date.ToShortTimeString()}): {Text}";
    }
}
