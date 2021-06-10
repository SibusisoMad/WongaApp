using MessageClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageClient.Services
{
   public interface IMessageService
    {
        void Send(MessageModel message);
        void Subscribe(MessageModel message);
    }
}
