using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Obrasoft.Data;
using Obrasoft.Models;

namespace Obrasoft.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ObrasoftDbContext _obrasoftDbContext;
        public ClienteRepository(ObrasoftDbContext ObrasoftDbContext)
        {
            _obrasoftDbContext = ObrasoftDbContext;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            cliente.Id = 0;
            _obrasoftDbContext.Clientes.Add(cliente);
            _obrasoftDbContext.SaveChanges();
            return cliente;
        }
        public List<Cliente> ObterTodos()
        {
            return _obrasoftDbContext.Clientes
                .Include(c => c.Cidade)
                .Include(c => c.Estado)
                .ToList();
        }

        public Cliente? ObterPorId(int id)
        {
            return _obrasoftDbContext.Clientes.Find(id);
        }

        public bool Deletar (int id)
        {
            var cliente = _obrasoftDbContext.Clientes.Find(id);

            if (cliente == null)
            {
                return false;
            }
            _obrasoftDbContext.Clientes.Remove(cliente);
            _obrasoftDbContext.SaveChanges ();

            return true;
        }
        public bool Editar(Cliente cliente)
        {
            var clienteExistente = _obrasoftDbContext.Clientes.Find(cliente.Id);
            if (clienteExistente == null) return false;

            _obrasoftDbContext.Entry(clienteExistente).CurrentValues.SetValues(cliente);
            return _obrasoftDbContext.SaveChanges() > 0;
        }



    }
}
