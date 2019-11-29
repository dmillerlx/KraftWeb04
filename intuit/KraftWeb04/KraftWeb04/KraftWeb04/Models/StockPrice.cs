using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftWeb04.Models
{
    public class StockPrice
    {
        public int Id { get; set; }
        public string StockSymbol { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
