using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorks.Ordering.API.OrderingMethods;

namespace TestWorks.Ordering.API.Tests.UnitTests
{
    [TestClass]
    public class AlphabeticAscOrderingMethodShould
    {
        static IOrderingMethod method = new AlphabeticAscOrderingMethod();

        [TestMethod]
        public void BeNamed()
            => method.Name.Should().Be("AlphabeticAsc");

        [TestMethod]
        public async Task ReturnOrderedWordsInAscendingOrder()
        {
            (await method.Order("bword cword\naword"))
                .Should().BeEquivalentTo("aword bword cword".Split(' '));

            (await method.Order("3word 2word\n1word")).Should()
                .BeEquivalentTo("1word 2word 3word".Split(' '));
        }
    }
}
