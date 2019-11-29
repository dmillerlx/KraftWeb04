using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftWeb04.Models
{
    public class DailyGainsLosses
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StockSymbol { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime DateTime { get; set; }
    }
}
