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
        static IOrderingMethodsRegistry registry = 
            new OrderingMethodsRegistry(new IOrderingMethod[]
            {
                    mockMethod("methodA"),
                    mockMethod("methodB")
            });


        [TestMethod]
        public void ReturnKeysFromRegisteredOrderingMethods()
        {
            registry.AllKeys.Should().BeEquivalentTo(new string[]
            {
                "methodA",
                "methodB"
            });
        }

        [TestMethod]
        public void RetrieveOrderingMethodRegardlessOfCasing()
        {
            var result = registry.GetByKey("Methoda");
            result.Should().NotBeNull();
            result.Name.Should().Be("methodA");

            result = registry.GetByKey("MethodB");
            result.Should().NotBeNull();
            result.Name.Should().Be("methodB");
        }

        [TestMethod]
        public void ThrowArgumentExceptionOnMissingMethod()
        {            
            registry
                .Invoking(reg => reg.GetByKey("nonExisting"))
                .Should().Throw<ArgumentException>("Should have thrown an argument exception on missing ordering method");
        }

        static IOrderingMethod mockMethod(string name)
        {
            var method = new Mock<IOrderingMethod>();
            method.Setup(m => m.Name).Returns(name);
            return method.Object;
        }
    }
}
