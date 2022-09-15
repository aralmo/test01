using System;
using System.Linq;
using System.Net.Http;
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

        [HttpGet, Route("options")]
        public GetOrderingOptionsResponse GetOptions()
            => new GetOrderingOptionsResponse()
            {
                Options = registry.AllKeys
            };
        
        [HttpPost, Route("order")]
        public async Task<GetOrderedWordsResponse> GetOrderedWords(GetOrderedWordsRequest request)
        {
            var method = 
                registry.GetByKey(request.OrderOption) ?? 
                throw new ArgumentException($"{request.OrderOption} is not a valid option", nameof(request.OrderOption));

            return new GetOrderedWordsResponse()
            {
                Words = await method.Order(request.TextToOrder)
            };
        }

        [HttpPost, Route("stats")]
        public async Task<GetStatisticsResponse> GetStatistics(GetStatisticsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}