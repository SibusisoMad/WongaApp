using System;
using System.Collections.Generic;
using System.Text;

namespace MessageClient.Helpers
{
   public interface IAppSettings
    {
        string GetHostName();

        string GetUsername();

        string GetPassword();

        string GetSentMessageKey();

        string GetResponseMessageKey();
    }
}
