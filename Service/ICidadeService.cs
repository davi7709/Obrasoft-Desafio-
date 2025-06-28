using Obrasoft.Models;

namespace Obrasoft.Service
{
    public interface ICidadeService
    {
        Task<List<Cidade>> GetCidadeEstado(int estadoId);

        Task<List<Cidade>> GetCidade();

    }

}
