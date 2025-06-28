using Obrasoft.Models;

namespace Obrasoft.Service
{
    public interface IClienteService
    {
        Task<List<Cliente>> ListarTodos();

        Task<Cliente> Adicionar(Cliente cliente);

        Task<Cliente?> ObterPorId(int id);

        Task<bool> Deletar(int id);

        Task<bool> Editar(Cliente cliente);
    }
}
