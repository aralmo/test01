using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorks.Ordering.API.OrderingMethods;

namespace TestWorks.Ordering.API.Tests.OrderingMethods
{
    [TestClass]
    public class AlphabeticDescOrderingMethodShould
    {
        static IOrderingMethod method = new AlphabeticDescOrderingMethod();

        [TestMethod]
        public async Task ReturnOrderedWordsInDescendingOrder()
        {
            (await method.Order("1word 3word 2word")).Should().Be("3word 2word 1word");
            (await method.Order("cword aword bword")).Should().Be("cword bword aword");
        }
    }
}
