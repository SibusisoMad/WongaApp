using MessageClient.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Wonga.Tests.Helpers
{
    public class AppSettingsTests
    {
        [Fact]
        public void CanGetValuesFromWebConfig()
        {
            //arrange
            var appSettings = new AppSettings();

            //assert
            Assert.Equals("localhost", appSettings.GetHostName());
            Assert.Equals("guest", appSettings.GetUsername());
            Assert.Equals("guest", appSettings.GetPassword());
            Assert.Equals("sentMessageKey", appSettings.GetSentMessageKey());
            Assert.Equals("responseMessageKey", appSettings.GetResponseMessageKey());
        }
    }
}