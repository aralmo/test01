using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorks.Ordering.API.Controllers;
using TestWorks.Ordering.API.OrderingMethods;

namespace TestWorks.Ordering.API.Tests.UnitTests
{
    [TestClass]
    public class OrderingControllerShould
    {
        [TestMethod]
        public void ReturnOptionsFromOptionsRegistry()
        {
            var registryMock = new Mock<IOrderingMethodsRegistry>();
            var methods = new string[]
            {
                "method 1",
                "method 2"
            };
            registryMock.Setup(m => m.AllKeys).Returns(methods);

            var controller = new OrderingController(registryMock.Object);

            controller
                .GetOptions().Options
                .Should().BeEquivalentTo(methods);

            registryMock.Verify(m => m.AllKeys, "Should have used the registry to get options");
        }
    }
}
