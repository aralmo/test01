using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWorks.Ordering.API.Models
{
    public struct GetOrderedWordsRequest
    {
        public string TextToOrder { get; set; }
        public string OrderOption { get; set; }
    }
}