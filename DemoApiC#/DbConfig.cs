using System.Data.Entity;
using DemoApiC_.Models;

namespace DemoApiC_
{
    public class DbConfig : DbContext
    {
        public DbSet<Dipendente> Dipendenti { get; set; }
    }
}