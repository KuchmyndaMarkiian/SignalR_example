using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using SignalR_Client.Abstractions;
using SignalR_Common_Features;
using SignalR_Common_Features.Models;
using static System.Console;

namespace SignalR_Client.Service
{
    class ChatService : IHubService, IUsableUsers
    {
        public User User { get; set; }
        public IHubProxy HubProxy { get; set; }
        public HubConnection HubConnection { get; set; }

        public Task ConfigureProxy(HubConnection hubConnection)
        {
            HubConnection = hubConnection;
            HubProxy = HubConnection.CreateHubProxy("MarkHub");
            HubProxy.On<Message>("addMessage", message =>
            {
                ForegroundColor = message.Sender.Color;
                WriteLine(message.ToString());
                ResetColor();
            });
            HubProxy.On<string>("onConnected", s => {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(s + " is connected");
                ResetColor();
            });
            HubProxy.On<string>("onDisconnected", s => {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(s + " is disconnected");
                ResetColor();
            });

            

            return hubConnection.Start();
        }

        public Task Connect()
        {
            return HubProxy.Invoke<string>("onConnected", User.Username)
                .ContinueWith(task =>
                {
                    if (task.IsFaulted) WriteLine($"Exception:{task.Exception.InnerException.Message}");
                });
        }

        public Task SendData(string data)
        {
            return HubProxy.Invoke("addMessage",
                    new Message {Sender = User, Text = data, Date = DateTime.Now})
                .ContinueWith(task =>
                {
                    if (task.IsFaulted) WriteLine($"Exception:{task.Exception.InnerException.Message}");
                });
        }

        public Task Disconnect()
        {
            return Task.Run(() =>
            {
                HubConnection.Stop();
            });
        }
    }
}
