using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestWorks.Ordering.API.Models;
using TestWorks.Ordering.API.OrderingMethods;

namespace TestWorks.Ordering.API.Controllers
{
    [RoutePrefix("ordering/v1/")]
    public class OrderingController : ApiController
    {
        private readonly IOrderingMethodsRegistry registry;

        public OrderingController(IOrderingMethodsRegistry registry)
        {
            this.registry = registry;
        }

        [Route("options")]
        public OrderingOptions GetOptions()
            => new OrderingOptions()
            {
                Options = registry.AllKeys
            };
    }
}