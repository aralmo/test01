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
    public class AlphabeticDescOrderingMethodShould
    {
        static IOrderingMethod method = new AlphabeticDescOrderingMethod();

        [TestMethod]
        public void BeNamed()
            => method.Name.Should().Be("AlphabeticDesc");


        [TestMethod]
        public async Task ReturnOrderedWordsInDescendingOrder()
        {
            (await method.Order("1word 3word 2word")).Should().BeEquivalentTo("3word 2word 1word".Split(' '));
            (await method.Order("cword aword bword")).Should().BeEquivalentTo("cword bword aword".Split(' '));
        }
    }
}
