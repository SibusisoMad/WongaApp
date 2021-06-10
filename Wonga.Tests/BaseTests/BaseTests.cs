using MessageClient.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wonga.Tests.BaseTests
{
    public class BaseTests
    {
        protected IErrorLogger MockErrorLogger { get; set; }
        public BaseTests()
        {
            MockErrorLogger = new Mock<IErrorLogger>().Object;
        }
    }
}
