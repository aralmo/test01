using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.Models
{
    public struct GetOrderedWordsResponse
    {
        public IEnumerable<string> Words { get; set; }
    }
}