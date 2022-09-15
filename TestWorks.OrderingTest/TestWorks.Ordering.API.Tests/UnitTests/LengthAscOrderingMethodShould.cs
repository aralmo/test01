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
    public class LengthAscOrderingMethodShould
    {
        static IOrderingMethod method = new LengthAscOrderingMethod();

        [TestMethod]
        public void BeNamed()
            => method.Name.Should().Be("LengthAsc");


        [TestMethod]
        public async Task ReturnWordsOrderedByAscendingLength()
        {
            (await method.Order("evenlongerword word longerword")).Should().Be("word longerword evenlongerword");
        }
    }

}
