using Microsoft.EntityFrameworkCore;
using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Database
{
    public class ConnectionContext : DbContext
    {
        
        public ConnectionContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cte> Cte { get; set; }
        public DbSet<CteInfCargaInfQ> CteInfCargaInfQ { get; set; }
    }
}
