using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraftWeb04.Models
{
    //public enum NotificationTypeEnum { StockWatch = 0};
    public class Notifications
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public char NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public bool Delivered { get; set; }
    }
}
