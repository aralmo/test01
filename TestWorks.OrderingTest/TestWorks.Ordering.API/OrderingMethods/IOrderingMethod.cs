using System.Threading.Tasks;

namespace TestWorks.Ordering.API.OrderingMethods
{
    public interface IOrderingMethod
    {
        Task<string> Order(string input);
    }
}