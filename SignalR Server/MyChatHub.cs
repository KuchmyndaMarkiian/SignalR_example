using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR_Common_Features;
using SignalR_Common_Features.Models;
using SignalR_Common_Features.Services;

namespace SignalR_Server
{
    [HubName("MarkHub")]
    public class MyChatHub : Hub
    {
        private static readonly List<User> Users;

        static MyChatHub()
        {
            Users = new List<User>();
        }

        [HubMethodName("addMessage")]
        public Task SendMessage(Message message)
        {
            return Task.Run(() =>
            {
                LoggerIO.PrintEvent(nameof(SendMessage),
                    $@"sender '{message.Sender}' content '{message.Text}' date '{message.Date}'");
                Clients.All.addMessage(message);
            });
        }

        [HubMethodName("onConnected")]
        public Task Connect(string username)
        {
            return Task.Run(() =>
            {
                if (Users.All(x => x.Id != Context.ConnectionId))
                {
                    Users.Add(new User {Id = Context.ConnectionId, Username = username});
                    Clients.Others.onConnected(username);
                    OverideEvents(nameof(OnConnected), Context.ConnectionId);
                }
            });
        }

        [HubMethodName("onDisconnected")]
        public override Task OnDisconnected(bool stopCalled)
        {
            Task.Run(() =>
                {
                    var user = Users.FirstOrDefault(x => x.Id == Context.ConnectionId);
                    Clients.All.onDisconnected(user.Username);
                    Users.Remove(user);
                    OverideEvents(nameof(OnDisconnected), Context.ConnectionId);
                })
                .Wait();
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
