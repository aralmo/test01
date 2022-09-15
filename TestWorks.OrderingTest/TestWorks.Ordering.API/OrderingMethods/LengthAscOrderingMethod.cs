using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    public class LengthAscOrderingMethod : IOrderingMethod
    {
        public string Name => "LengthAsc";

        public Task<string[]> Order(string input)
            => Task.FromResult(input.SplitWords().OrderBy(word => word.Length).ToArray());
    }
}