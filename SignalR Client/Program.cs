using System;
using Microsoft.AspNet.SignalR.Client;
using SignalR_Client.Abstractions;
using SignalR_Client.Service;
using SignalR_Common_Features;
using SignalR_Common_Features.Models;
using static System.Console;

namespace SignalR_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Client is starting on {Constants.Url}");

            var hubConnection = new HubConnection(Constants.Url);
            Write("Enter username:");
            string username = ReadLine();
            IHubService hubService = new ChatService()
            {
                User = new User() {Username = username,Id = "null",Color = (ConsoleColor) Enum.ToObject(typeof(ConsoleColor), new Random().Next(1, 15))}
            };
            hubService.ConfigureProxy(hubConnection).Wait();
            hubService.Connect().Wait();
            while (true)
            {
                string message = ReadLine();
                if (message != null && message.Contains("_exit_"))
                {
                    hubService.Disconnect().Wait();
                    break;
                }
                if(string.IsNullOrWhiteSpace(message))
                    continue;
                hubService.SendData(message).Wait();
            }
        }
    }
}
