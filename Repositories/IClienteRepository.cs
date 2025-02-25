using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public interface IClienteRepository
    {
        Cliente Adicionar(Cliente cliente);

        List<Cliente> ObterTodos();

        bool Editar(Cliente cliente);

        bool Deletar(int Id);

        Cliente? ObterPorId(int Id);
    }
}
