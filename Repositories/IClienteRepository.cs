using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public interface IClienteRepository
    {
        Cliente Adicionar(Cliente cliente);

        List<Cliente> ObterTodos();
    }
}
