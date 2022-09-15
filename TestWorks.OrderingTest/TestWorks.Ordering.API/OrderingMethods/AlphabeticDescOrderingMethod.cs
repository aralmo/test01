using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    internal class AlphabeticDescOrderingMethod : IOrderingMethod
    {
        public string Name => "AlphabeticDesc";

        public Task<string[]> Order(string input)
            => Task.FromResult(input.Split(' ').OrderByDescending(word => word).ToArray());
    }
}