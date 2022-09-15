using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestWorks.Ordering.API.TextAnalysis
{
    public interface ITextAnalyzer
    {
        Task<TextAnalyzerResult> AnalyzeText(string text);
    }
}