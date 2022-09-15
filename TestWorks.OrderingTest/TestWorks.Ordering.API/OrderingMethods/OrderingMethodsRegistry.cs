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

        public IEnumerable<string> AllKeys
            => orderingMethods.Select(om => om.Name);

        public IOrderingMethod GetByKey(string key)
            => orderingMethods
            .FirstOrDefault(om => string.Compare(om.Name, key, true) == 0)
            ?? throw new ArgumentException($"ordering method {key} not found", nameof(key));
        
    }
}