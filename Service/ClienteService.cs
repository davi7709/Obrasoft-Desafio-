using Obrasoft.Models;
using Obrasoft.Repositories;

namespace Obrasoft.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> ListarTodos()
        {
            return await _clienteRepository.ObterTodos();
        }

        public async Task<Cliente?> ObterPorId(int Id)
        {
            var cliente = _clienteRepository.ObterPorId(Id);

            if (cliente == null)
            {
                throw new Exception($"Usuario com Id {Id} não encontrado");
            }
            return await cliente;
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            var clienteExistente = await _clienteRepository.ObterPorDocumento(cliente.NrDocumento);
            if (clienteExistente != null)
            {
                throw new Exception($"Usuario já cadastrado com esse documento");
            }

            if (string.IsNullOrWhiteSpace(cliente.NrDocumento))
            {
                throw new Exception($"Campo Obrigatorio");
            }
            return await _clienteRepository.Adicionar(cliente);
        }

        public async Task<bool> Deletar(int id)
        {
            await _clienteRepository.Deletar(id);
            return true;
        }

        public async Task<bool> Editar(Cliente clienteAtualizado)
        {
            var clienteCadastrado = await _clienteRepository.ObterPorId(clienteAtualizado.Id);

            if (clienteCadastrado == null)
            
                return false;

                clienteCadastrado.Nome = clienteAtualizado.Nome;
                clienteCadastrado.NrDocumento = clienteAtualizado.NrDocumento;
                clienteCadastrado.DataNascimento = clienteAtualizado.DataNascimento;
                clienteCadastrado.Endereco = clienteAtualizado.Endereco;
                clienteCadastrado.Numero = clienteAtualizado.Numero;
                clienteCadastrado.EstadoId = clienteAtualizado.EstadoId;
                clienteCadastrado.CidadeId = clienteAtualizado.CidadeId;

                return await _clienteRepository.Editar(clienteCadastrado);

        }
    }
}
