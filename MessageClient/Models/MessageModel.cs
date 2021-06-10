using MessageClient.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageClient.Models
{
   public class MessageModel
    {
        public MessageType Type { get; set; }
        public Action<string> MessageHandler { get; set; }
        public string Name { get; set; }
    }
}
