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
    public class AlphabeticAscOrderingMethodShould
    {
        static IOrderingMethod method = new AlphabeticAscOrderingMethod();

        [TestMethod]
        public async Task ReturnOrderedWordsInAscendingOrder()
        {
            (await method.Order("bword cword aword")).Should().Be("aword bword cword");
            (await method.Order("3word 2word 1word")).Should().Be("1word 2word 3word");
        }
    }
}
