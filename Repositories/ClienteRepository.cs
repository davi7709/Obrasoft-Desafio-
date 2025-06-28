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
        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            try
            {
                cliente.Id = 0;
                _obrasoftDbContext.Clientes.Add(cliente);
                await _obrasoftDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao adicionar cliente ao banco de dados",ex);
            }
            return cliente;
        }
        public async Task<List<Cliente>> ObterTodos()
        {
            return await _obrasoftDbContext.Clientes
                .Include(c => c.Cidade)
                .Include(c => c.Estado)
                .ToListAsync();
        }

        public async Task<Cliente?> ObterPorId(int id)
        {
            return await _obrasoftDbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<bool> Deletar(int id)
        {
            try
            {
                var clienteExistente = await _obrasoftDbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);

                if (clienteExistente == null)
                    return false; 

                _obrasoftDbContext.Clientes.Remove(clienteExistente);
                return await _obrasoftDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> Editar(Cliente cliente)
        {
            var clienteExistente = await ObterPorId(cliente.Id);
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

            return await _obrasoftDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Cliente?> ObterPorDocumento (String nrDocumento)
        {
            return await _obrasoftDbContext.Clientes.FirstOrDefaultAsync(x => x.NrDocumento == nrDocumento);
        }


    }
}
