using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorks.Ordering.API.TextAnalysis;

namespace TestWorks.Ordering.API.Tests.UnitTests
{
    [TestClass]
    public class TextAnalyzerShould
    {
        [TestMethod]
        public async Task ReturnCorrectCountMetrics()
        {
            var analyzer = new TextAnalyzer();
            var result =await analyzer.AnalyzeText("this text contains some-words and other-characters");
            
            result.Words.Should().Be(6);
            result.Hyphens.Should().Be(2);
            result.Spaces.Should().Be(5);
        }
    }
}
