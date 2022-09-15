using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    public interface IOrderingMethodsRegistry
    {
        IEnumerable<string> AllKeys { get; }
    }
}