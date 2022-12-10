using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Viktorine.Models;

namespace Viktorine
{
    public class AppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<VariableQuote> VariableQuotes { get; set; }
        public DbSet<Victorine> Victorines { get; set; }
        public DbSet<VictorineQuote> VictorineQuotes { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public AppContext() => Database.Migrate();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Viktorine.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariableQuote>().Property(u => u.Id).ValueGeneratedOnAdd();
        }

    }
}
