using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftWeb04.Models
{
    //public enum StockWatchNotificationRouteEnum { InApp=0, Email=1, Push=2, Sms=3};
    public class StockWatch
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StockSymbol { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }
        public char NotificationType { get; set; }
        public DateTime StartDate { get; set; }
    }
}
