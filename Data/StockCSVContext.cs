using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockCSV.Models;

namespace StockCSV.Data
{
    public class StockCSVContext : DbContext
    {
        public StockCSVContext (DbContextOptions<StockCSVContext> options)
            : base(options)
        {
        }

        public DbSet<StockCSV.Models.Holding> Holding { get; set; } = default!;
    }
}
