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
            var cidadeDoEstado = await _cidadeRepository.GetCidadeEstado(estadoId);

            if(cidadeDoEstado == null || !cidadeDoEstado.Any())
            {
                return await _cidadeRepository.GetCidade();
            }

            return cidadeDoEstado;
        }
    }
}
