using System;
using System.Text;
using RabbitMQ.Client;
using MessageClient.Enums;
using MessageClient.Helpers;
using MessageClient.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;

namespace MessageClient.Services
{
    public class MessageService : IMessageService
    {
        #region Properties
        private readonly IErrorLogger _logger;
        private IModel Channel { set; get; }
        private IConnection Connection { set; get; }
        private MessageModel MessageModel { set; get; }
        private readonly IAppSettings _appSettings;
        #endregion

        #region Constructors
        public MessageService(IAppSettings appSettings, IErrorLogger logger)
        {
            _logger = logger;
            _appSettings = appSettings;
            CreateConnection();
        }
        #endregion

        #region Public Methods
        public void Send(MessageModel messageModel)
        {
            try
            {
                if (string.IsNullOrEmpty(messageModel.Name))
                {
                    messageModel.MessageHandler.Invoke("Name is required");
                    DisposeConnection();
                    return;
                }
                MessageModel = messageModel;
                QueueDeclare();
                var body = Encoding.UTF8.GetBytes(string.Format(GetMessageByMessageType(), messageModel.Name));
                Channel.BasicPublish(string.Empty, GetKeyByMessageType(), null, body);
            }
            catch (Exception ex)
            {
                string error = "An error occurred and your request was unscuccessful";
                _logger.Log(LogLevel.Critical, ex, error);
                messageModel.MessageHandler.Invoke(error);
                DisposeConnection();
            }

        }

        public void Subscribe(MessageModel messageModel)
        {
            try
            {
                MessageModel = messageModel;
                QueueDeclare();
                Consume();
            }
            catch (Exception ex)
            {
                string error = "An error occurred and your request was unscuccessful";
                _logger.Log(LogLevel.Critical, ex, error);
                messageModel.MessageHandler.Invoke(error);
                DisposeConnection();
            }
        }
        #endregion

        #region Private Methods
        private void CreateConnection()
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory();
                {
                    factory.HostName = _appSettings.GetHostName();
                    factory.UserName = _appSettings.GetUsername();
                    factory.Password = _appSettings.GetPassword();
                    factory.VirtualHost = "/";
                    factory.Port = 5672;
                    factory.RequestedHeartbeat = TimeSpan.FromSeconds(60);
                    factory.AutomaticRecoveryEnabled = true;
                    IConnection conn = factory.CreateConnection();

                };


                Connection = factory.CreateConnection();
                Channel = Connection.CreateModel();
            }
            catch (Exception ex)
            {
                string error = "An error occurred and your request was unscuccessful";
                _logger.Log(LogLevel.Critical, ex, error);
                MessageModel.MessageHandler.Invoke(error);
                DisposeConnection();
            }
        }
        private void DisposeConnection()
        {
            Connection?.Dispose();
            Channel?.Dispose();
        }
        private void QueueDeclare()
        {
            Channel.QueueDeclare(GetKeyByMessageType(), false, false, false, null);
        }
        private void Consume()
        {
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += ReceivedRequestEvent;
            Channel.BasicConsume(GetKeyByMessageType(), true, consumer);
        }
        private void ReceivedRequestEvent(object model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var receivedMessage = Encoding.UTF8.GetString(body);

            //show message
            MessageModel.MessageHandler.Invoke(receivedMessage);

            if (!string.IsNullOrEmpty(receivedMessage) && MessageModel.Type == MessageType.Message)
            {

                //send response to sender
                var name = receivedMessage.Substring(receivedMessage.IndexOf(",", StringComparison.Ordinal) + 1);
                var message = new MessageModel
                {
                    Name = name,
                    Type = MessageType.Response
                };
                Send(message);
            }
            else
                DisposeConnection();
        }
        private string GetKeyByMessageType()
        {
            return MessageModel.Type == MessageType.Message
                ? _appSettings.GetSentMessageKey()
                : _appSettings.GetResponseMessageKey();
        }

        private string GetMessageByMessageType()
        {
            return MessageModel.Type == MessageType.Message
                ? "Hello my name is, {0}"
                : "Hello {0}, I'm your father";
        }
        #endregion
    }
}