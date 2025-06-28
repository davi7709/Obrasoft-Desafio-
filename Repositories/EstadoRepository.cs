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

        public async Task<List<Estado>> GetEstado()
        {
            return await _ObrasoftDbContext.Estados
                                .Include(e => e.Cidades)  // Inclui as cidades do estado
                                .ToListAsync();
        }
    }
}
