using Microsoft.EntityFrameworkCore;
using Obrasoft.Data;
using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ObrasoftDbContext _ObrasoftDbContext;

        public EstadoRepository(ObrasoftDbContext ObrasoftDbContext)
        {
            _ObrasoftDbContext = ObrasoftDbContext;
        }

        public List<Estado> GetEstado()
        {
            return _ObrasoftDbContext.Estados
                                .Include(e => e.Cidades)  // Inclui as cidades do estado
                                .ToList();
        }
    }
}
