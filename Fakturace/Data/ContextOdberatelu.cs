using Microsoft.EntityFrameworkCore;
using Fakturace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturace.Data
{
    public class ContextOdberatelu : DbContext
    {
        public DbSet<Odberatel> Odberatele { get; set; }

        public ContextOdberatelu()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FakturaceOdberatelu.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
