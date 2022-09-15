using System.Threading.Tasks;

namespace TestWorks.Ordering.API.OrderingMethods
{
    public interface IOrderingMethod
    {
        string Name { get; }
        Task<string[]> Order(string input);
    }
}