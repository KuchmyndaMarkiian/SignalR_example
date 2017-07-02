using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace SignalR_Client.Abstractions
{
    interface IHubService
    {
        /// <summary>
        /// Client side socket
        /// </summary>
        IHubProxy HubProxy { get; set; }
        /// <summary>
        /// Connectline for interaction with server(hub)
        /// </summary>
        HubConnection HubConnection { get; set; }
        /// <summary>
        /// Config hub`s methods
        /// </summary>
        /// <param name="hubConnection"></param>
        /// <returns></returns>
        Task ConfigureProxy(HubConnection hubConnection);
        /// <summary>
        /// Event while user is connecting
        /// </summary>
        /// <returns></returns>
        Task Connect();
        /// <summary>
        /// Sending message
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task SendData(string data);
        /// <summary>
        /// Event while user is disconnecting
        /// </summary>
        /// <returns></returns>
        Task Disconnect();
    }
}
