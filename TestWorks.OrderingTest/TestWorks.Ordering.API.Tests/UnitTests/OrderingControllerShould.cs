using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using TestWorks.Ordering.API.Controllers;
using TestWorks.Ordering.API.Models;
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

        [TestMethod]
        public async Task ThrowBadRequestExceptionOnMissingOrderingMethod()
        {
            var registryMock = new Mock<IOrderingMethodsRegistry>();
            registryMock.Setup(m => m.AllKeys).Returns(new string[0]);

            var controller = new OrderingController(registryMock.Object);

            await controller
                .Invoking(c => c.GetOrderedWords(new GetOrderedWordsRequest()
                {
                    OrderOption = "nonexisting",
                    TextToOrder = String.Empty
                }))
                .Should().ThrowAsync<ArgumentException>()
                .Where(ex => ex.ParamName == nameof(GetOrderedWordsRequest.OrderOption));
        }

        [TestMethod]
        public async Task UseTheRequestedOrderingMethod()
        {
            var optionA = new Mock<IOrderingMethod>();
            optionA.Setup(m => m.Name).Returns("optiona");

            optionA
                .Setup(m => m.Order(It.IsAny<string>()))
                .Returns(Task.FromResult(new string[] { "optionA" }));

            var optionB = new Mock<IOrderingMethod>();
            optionA.Setup(m => m.Name).Returns("optionb");
            optionA
                .Setup(m => m.Order(It.IsAny<string>()))
                .Returns(Task.FromResult(new string[] { "optionB" }));

            var registry = new OrderingMethodsRegistry(new IOrderingMethod[] { optionA.Object, optionB.Object });

            var controller = new OrderingController(registry);

            //assert 

            
            var result = await controller.GetOrderedWords(new GetOrderedWordsRequest()
            {
                TextToOrder = "sometext",
                OrderOption = "optionB"
            });

            result.Words.Should().BeEquivalentTo(new string[] { "optionB" });
        }
    }
}
