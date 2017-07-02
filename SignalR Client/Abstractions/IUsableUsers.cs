using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_Common_Features.Models;

namespace SignalR_Client.Abstractions
{
    interface IUsableUsers
    {
        User User { get; set; }
    }
}
