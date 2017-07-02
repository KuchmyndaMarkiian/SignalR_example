using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Common_Features
{
    public class Message
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        //public DateTime Date { get; set; }

        public override string ToString() => $"{Sender}({1/*Date.ToShortTimeString()*/}): {Text}";
    }
}
