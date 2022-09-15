using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    internal class AlphabeticAscOrderingMethod : IOrderingMethod
    {
        public string Name => "AlphabeticAsc";

        public Task<string[]> Order(string input)
            => Task.FromResult(input.SplitWords().OrderBy(word => word).ToArray());
    }
}