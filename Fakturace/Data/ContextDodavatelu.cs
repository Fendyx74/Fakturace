using Fakturace.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturace.Data
{
    public class ContextDodavatelu : DbContext
    {
        public DbSet<Dodavatel> Dodavatele { get; set; }

        public ContextDodavatelu()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FakturaceDodavatele.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
