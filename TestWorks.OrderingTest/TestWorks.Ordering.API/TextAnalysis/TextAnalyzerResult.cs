using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.TextAnalysis
{
    public struct TextAnalyzerResult
    {

        public int Words { get; }
        public int Spaces { get; }
        public int Hyphens { get; }

        public TextAnalyzerResult(int words, int spaces, int hyphens)
        {
            Words = words;
            Spaces = spaces;
            Hyphens = hyphens;
        }
    }
}