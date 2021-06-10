using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MessageClient.Helpers
{
   public class AppSettings : IAppSettings
    {
        #region Declaration

        private static IConfiguration Configuration { get; set; }

        #endregion

        #region Constructors
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        #endregion

        #region Public Methods

        public string GetHostName()
        {
            return Configuration["hostname"];
        }
        public string GetUsername()
        {
            return Configuration["username"];
        }
        public string GetPassword()
        {
            return Configuration["password"];
        }
        public string GetSentMessageKey()
        {
            return Configuration["sentmessagekey"];
        }
        public string GetResponseMessageKey()
        {
            return Configuration["responsemessagekey"];
        }

        #endregion
    }
}
