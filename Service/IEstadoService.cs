using Obrasoft.Models;

namespace Obrasoft.Service
{
    public interface IEstadoService
    {
        Task<List<Estado>> GetEstados();
    }
}
