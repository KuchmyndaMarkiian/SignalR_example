using System;
using Microsoft.AspNet.SignalR.Client;
using SignalR_Common_Features;
using static System.Console;

namespace SignalR_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Client is starting on {Constants.Url}");
            var hubConnection = new HubConnection(Constants.Url)
            {
                TraceWriter = Console.Out,
                TraceLevel = TraceLevels.All
            };
            var hubProxy = hubConnection.CreateHubProxy("MarkHub");
            hubProxy.On<Message>("addMessage", message =>
            {
                ForegroundColor = ConsoleColor.DarkCyan;
                WriteLine(message.ToString());
                ResetColor();
            });


            hubConnection.Start().Wait();
            Write("Enter username:");
            string username = ReadLine();
            while (true)
            {
                string message = ReadLine();
                hubProxy.Invoke<Message>("addMessage",
                    new Message() {Sender = username, Text = message, /*Date = DateTime.Now*/}).ContinueWith(task =>
                {
                    if(task.IsFaulted)
                        WriteLine($"Exception:{task.Exception.Message}");
                    else
                    {
                        WriteLine("is sended");
                    }
                }).Wait();
            }


        }
    }
}
