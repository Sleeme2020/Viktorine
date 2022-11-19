using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Viktorine.Models;

namespace Viktorine
{
    public class AppContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }

        public AppContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Viktorine.db");
        }

    }
}
