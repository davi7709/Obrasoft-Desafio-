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

        public async Task<List<Estado>> GetEstados()
        {
            return await _estadoRepository.GetEstado();
        }
    }
}
