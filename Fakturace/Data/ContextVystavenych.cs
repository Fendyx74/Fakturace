using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fakturace.Model;

namespace Fakturace.Data
{
    public class ContextVystavenych : DbContext
    {
        public DbSet<Faktura> Faktury { get; set; }

        public ContextVystavenych()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FakturaceVystavene.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
