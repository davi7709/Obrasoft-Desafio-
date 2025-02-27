using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obrasoft.Controllers;
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
            return _obrasoftDbContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public bool Deletar(int id)
        {
            try
            {
                var clienteExistente = _obrasoftDbContext.Clientes.FirstOrDefault(c => c.Id == id);

                if (clienteExistente == null)
                    return false; 

                _obrasoftDbContext.Clientes.Remove(clienteExistente);
                return _obrasoftDbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
                return false;
            }
        }


        public bool Editar(Cliente cliente)
        {
            var clienteExistente = ObterPorId(cliente.Id);
            if (clienteExistente == null)
                return false;

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.NrDocumento = cliente.NrDocumento;
            clienteExistente.DataNascimento = cliente.DataNascimento;
            clienteExistente.Endereco = cliente.Endereco;
            clienteExistente.Numero = cliente.Numero;
            clienteExistente.EstadoId = cliente.EstadoId;
            clienteExistente.CidadeId = cliente.CidadeId;

            _obrasoftDbContext.Entry(clienteExistente).State = EntityState.Modified;

            return _obrasoftDbContext.SaveChanges() > 0;
        }




    }
}
