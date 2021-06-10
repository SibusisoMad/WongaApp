using MessageClient.Enums;
using MessageClient.Helpers;
using MessageClient.Models;
using MessageClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace SenderApp
{
     internal class Send
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("SENDER");
            Console.WriteLine("Please enter your name");

            var serviceProvider = GetServiceProvider();
            var messageService = serviceProvider.GetService<IMessageService>();

            var name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter your name");
                name = Console.ReadLine();
            }

            //send message
            var messageModel = new MessageModel
            {
                Name = name,
                Type = MessageType.Message,
                MessageHandler = ShowMessage
            };

            messageService.Send(messageModel);


            //subscribe to message response
            var responseModel = new MessageModel
            {
                Type = MessageType.Response,
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
                .AddTransient<IErrorLogger, ErrorLogger<Send>>()
                .BuildServiceProvider();
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
