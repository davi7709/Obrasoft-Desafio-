using Microsoft.EntityFrameworkCore;
using Obrasoft.Models;

namespace Obrasoft.Data
{
    public class ObrasoftDbContext : DbContext
    {
        public ObrasoftDbContext(DbContextOptions<ObrasoftDbContext> options) 
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
    }
}
