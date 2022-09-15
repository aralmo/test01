using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.OrderingMethods
{
    public static class StringExtensions
    {
        public static string[] SplitWords(this string input)
            => input.Split(new char[] { ' ', '\n' });
    }
}