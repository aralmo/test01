using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorks.Ordering.API.OrderingMethods;

namespace TestWorks.Ordering.API.Tests.UnitTests
{
    [TestClass]
    public class OrderingMethodsRegistryShould
    {
        [TestMethod]
        public void ReturnKeysFromRegisteredOrderingMethods()
        {
            var registry = new OrderingMethodsRegistry(new IOrderingMethod[]
            {
                mockMethod("methodA"),
                mockMethod("methodB")
            });

            registry.AllKeys.Should().BeEquivalentTo(new string[]
            {
                "methodA",
                "methodB"
            });
        }

        IOrderingMethod mockMethod(string name)
        {
            var method = new Mock<IOrderingMethod>();
            method.Setup(m => m.Name).Returns(name);
            return method.Object;
        }
    }
}
