using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fakturace.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Fakturace.Data
{
    public class ContextPrijatych : DbContext
    {
        public DbSet<Faktura> Faktury { get; set; }

        public ContextPrijatych()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FakturacePrijate.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}

