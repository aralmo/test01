using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestWorks.Ordering.API.Models;
using TestWorks.Ordering.API.OrderingMethods;
using TestWorks.Ordering.API.TextAnalysis;

namespace TestWorks.Ordering.API.Controllers
{
    [RoutePrefix("ordering/v1")]
    public class OrderingController : ApiController
    {
        private readonly IOrderingMethodsRegistry registry;
        private readonly ITextAnalyzer textAnalyzer;

        public OrderingController(IOrderingMethodsRegistry registry, ITextAnalyzer textAnalyzer)
        {
            this.registry = registry;
            this.textAnalyzer = textAnalyzer;
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
            var stats = await textAnalyzer.AnalyzeText(request.TextToAnalyze);
            return new GetStatisticsResponse()
            {
                HyphenCount = stats.Hyphens,
                WordCount = stats.Words,
                SpaceCount = stats.Spaces
            };
        }
    }
}