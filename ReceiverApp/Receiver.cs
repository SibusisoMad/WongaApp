using MessageClient.Enums;
using MessageClient.Helpers;
using MessageClient.Models;
using MessageClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ReceiverApp
{
    internal class Receiver
    {
        private static void Main()
        {

            Console.WriteLine("WONGA RECEIVER ");

            var serviceProvider = GetServiceProvider();
            var messageService = serviceProvider.GetService<IMessageService>();

            //subscribe to message
            var responseModel = new MessageModel
            {
                Type = MessageType.Message,
                MessageHandler = ShowMessage
            };
            messageService.Subscribe(responseModel);

            Console.ReadLine();
        }
        private static ServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IAppSettings, AppSettings>()
                .AddTransient<IMessageService, MessageService>()
                .AddTransient<ILoggerFactory>(x => new LoggerFactory())
                .AddTransient<IErrorLogger, ErrorLogger<Receiver>>()
                .BuildServiceProvider();
        }
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
