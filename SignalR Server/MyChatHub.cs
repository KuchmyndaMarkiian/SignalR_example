using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR_Common_Features;
using SignalR_Common_Features.Services;

namespace SignalR_Server
{
    [HubName("MarkHub")]
    public  class MyChatHub : Hub
    {
        public void SendMessage(Message message)
        {
            LoggerIO.PrintEvent(nameof(SendMessage),
                $@"sender '{message.Sender}' content '{message.Text}' date '{11/*message.Date*/}'");
            Clients.All.addMessage(message);
        }

        public override Task OnConnected()
        {
            OverideEvents(nameof(OnConnected), Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            OverideEvents(nameof(OnDisconnected), Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            OverideEvents(nameof(OnReconnected), Context.ConnectionId);
            return base.OnReconnected();
        }

        private void OverideEvents(string method, string id) => LoggerIO.PrintEvent(method, $"Hub {method} {id}");
    }
}
