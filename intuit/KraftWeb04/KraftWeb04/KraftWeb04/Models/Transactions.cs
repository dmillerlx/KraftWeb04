using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftWeb04.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StockSymbol { get; set; }
        public decimal Price { get; set; }
        public char TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; }        
    }
}
