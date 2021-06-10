using MessageClient.Enums;
using MessageClient.Helpers;
using MessageClient.Models;
using MessageClient.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Wonga.Tests.Services
{
    public class MessageServiceTests : BaseTests.BaseTests
    {
        [Fact]
        public void SendDoesNotAllowNulls()
        {
            //arrange
            var message = string.Empty;
            var action = new Action<string>(x =>
            {
                message = x;
            });

            var messageModel = new MessageModel
            {
                Name = null,
                Type = MessageType.Message,
                MessageHandler = action
            };

            //act
            var service = new MessageService(new AppSettings(), MockErrorLogger);
            service.Send(messageModel);

            //assert
            Assert.Equals("Name is required", message);
        }

        [Fact]
        public void SendDoesNotAllowEmptyStrings()
        {
            //arrange
            var message = string.Empty;
            var action = new Action<string>(x =>
            {
                message = x;
            });

            var messageModel = new MessageModel
            {
                Name = string.Empty,
                Type = MessageType.Message,
                MessageHandler = action
            };

            //act
            var service = new MessageService(new AppSettings(), MockErrorLogger);
            service.Send(messageModel);

            //assert
            Assert.Equals("Name is required", message);
        }

        [Fact]
        public async Task MessageServiceCanSendAReply()
        {
            //arrange
            var message = string.Empty;
            var action = new Action<string>(x =>
            {
                message = x;
            });

            var messageModel = new MessageModel
            {
                Name = "Wonga",
                Type = MessageType.Message,
                MessageHandler = action
            };

            var responseModel = new MessageModel
            {
                Type = MessageType.Response,
                MessageHandler = action
            };

            var responseModel2 = new MessageModel
            {
                Type = MessageType.Message,
                MessageHandler = action
            };

            var serviceForApp1 = new MessageService(new AppSettings(), MockErrorLogger);
            var serviceForApp2 = new MessageService(new AppSettings(), MockErrorLogger);

            //act

            //app 1 sends message
            serviceForApp1.Send(messageModel);

            //app 2 subscribes to message
            serviceForApp2.Subscribe(responseModel2);

            //app 1 subscribes to response
            serviceForApp1.Subscribe(responseModel);



            //assert
            await Task.Delay(100);
            Assert.Equals("Hello  Wonga, I'm your father", message);
        }
    }
}

