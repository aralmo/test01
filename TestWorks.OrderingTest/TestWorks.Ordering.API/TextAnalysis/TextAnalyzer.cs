using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestWorks.Ordering.API.TextAnalysis
{
    public class TextAnalyzer : ITextAnalyzer
    {
        public Task<TextAnalyzerResult> AnalyzeText(string text)
            => Task.FromResult(new TextAnalyzerResult(
                    words: text.Split(' ').Length,
                    spaces: text.Count(c => c == ' '),
                    hyphens: text.Count(c => c == '-')
                ));
    }
}