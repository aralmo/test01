using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.Models
{
    public struct GetStatisticsResponse
    {
        //hyphens quantity, word quantity, spaces quantity
        public int WordCount { get; set; }
        public int HyphenCount { get; set; }
        public int SpaceCount { get; set; }
    }
}