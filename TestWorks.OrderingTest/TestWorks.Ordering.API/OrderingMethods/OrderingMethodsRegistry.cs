using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    internal class OrderingMethodsRegistry : IOrderingMethodsRegistry
    {
        private readonly IEnumerable<IOrderingMethod> orderingMethods;

        public OrderingMethodsRegistry(IEnumerable<IOrderingMethod> orderingMethods)
        {
            this.orderingMethods = orderingMethods;
        }

        public IEnumerable<string> AllKeys => throw new NotImplementedException();
    }
}