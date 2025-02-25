using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public interface ICidadeRepository
    {
        List<Cidade> GetCidadeEstado(int estadoId);
    }
}
