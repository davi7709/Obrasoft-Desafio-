using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> Adicionar(Cliente cliente);

        Task<List<Cliente>> ObterTodos();

        Task<bool> Editar(Cliente cliente);

        Task<bool> Deletar(int Id);

        Task<Cliente?> ObterPorId(int Id);

        Task<Cliente?> ObterPorDocumento(string nrDocumento);

    }
}
