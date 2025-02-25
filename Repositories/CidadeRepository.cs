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

        public List<Cidade> GetCidadeEstado(int estadoId)
        {
            return _obrasoftDbContext.Cidades
                                .Where(c => c.EstadoId == estadoId)
                                .ToList();
        }
    }
}
