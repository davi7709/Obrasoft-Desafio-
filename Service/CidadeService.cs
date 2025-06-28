using Obrasoft.Models;
using Obrasoft.Repositories;

namespace Obrasoft.Service
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }
        public async Task<List<Cidade>> GetCidade()
        {
            return await _cidadeRepository.GetCidade();
        }
        public async Task<List<Cidade>> GetCidadeEstado(int estadoId)
        {
            return await _cidadeRepository.GetCidadeEstado(estadoId);
        }
    }
}
