using Obrasoft.Models;
using Obrasoft.Repositories;

namespace Obrasoft.Service
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<List<Estado>> GetEstado()
        {
            return await _estadoRepository.GetEstado();
        }

        public async Task<List<Estado>> GetEstadoECidade()
        {
            return await _estadoRepository.GetEstadoECidade();
        }
    }
}
