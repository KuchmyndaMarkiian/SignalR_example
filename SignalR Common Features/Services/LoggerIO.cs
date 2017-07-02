using System;

namespace SignalR_Common_Features.Services
{
    // ReSharper disable once InconsistentNaming
    public static class LoggerIO
    {
        public static void PrintEvent(string methodName, string content) => Console.WriteLine(
            $@"Method '{methodName}': {content}");
    }
}
