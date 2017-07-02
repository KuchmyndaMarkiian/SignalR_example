using System;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using SignalR_Common_Features;
using SignalR_Server;
using static System.Console;
[assembly:OwinStartup(typeof(Startup))]

namespace SignalR_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (WebApp.Start(Constants.Url))
                {
                    WriteLine($"Server is starting on {Constants.Url}");

                    while (true)
                    {
                        ReadKey(true);
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }
}
