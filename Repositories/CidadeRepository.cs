using Microsoft.EntityFrameworkCore;
using Obrasoft.Data;
using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly ObrasoftDbContext _obrasoftDbContext;

        public CidadeRepository(ObrasoftDbContext ObrasoftDbContext)
        {
            _obrasoftDbContext = ObrasoftDbContext;
        }

        public async Task<List<Cidade>> GetCidadeEstado(int estadoId)
        {
            return await _obrasoftDbContext.Cidades
                                .Where(c => c.EstadoId == estadoId)
                                .ToListAsync();
        }

        public async Task<List<Cidade>> GetCidade()
        {
            return await _obrasoftDbContext.Cidades.ToListAsync();
        }
    }
}
