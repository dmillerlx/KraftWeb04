using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KraftWeb04.Models;

namespace KraftWeb04.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //public DbSet<KraftWeb04.Models.TodoItem> TodoItem { get; set; }

        public DbSet<KraftWeb04.Models.Transactions> Transactions { get; set; }

        //public DbSet<KraftWeb04.Models.TodoItem> TodoItem { get; set; }

        public DbSet<KraftWeb04.Models.Holdings> Holdings { get; set; }

        //public DbSet<KraftWeb04.Models.TodoItem> TodoItem { get; set; }

        public DbSet<KraftWeb04.Models.StockPrice> StockPrice { get; set; }

        //public DbSet<KraftWeb04.Models.TodoItem> TodoItem { get; set; }

        public DbSet<KraftWeb04.Models.DailyGainsLosses> DailyGainsLosses { get; set; }

        //public DbSet<KraftWeb04.Models.TodoItem> TodoItem { get; set; }

        public DbSet<KraftWeb04.Models.StockWatch> StockWatch { get; set; }

        //public DbSet<KraftWeb04.Models.TodoItem> TodoItem { get; set; }

        public DbSet<KraftWeb04.Models.Notifications> Notifications { get; set; }
    }
}
