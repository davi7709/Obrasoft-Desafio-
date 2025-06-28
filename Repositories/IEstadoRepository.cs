using Obrasoft.Data;
using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public interface IEstadoRepository
    {
        Task<List<Estado>> GetEstado();
    }
}
