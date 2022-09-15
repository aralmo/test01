using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    public class AlphabeticDescOrderingMethod : IOrderingMethod
    {
        public Task<string> Order(string input)
            => Task.FromResult(string.Join(" ", input.Split(' ').OrderByDescending(word => word)));
    }
}