using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obrasoft.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string NrDocumento { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public int Numero { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public Estado? Estado { get; set; }
        public Cidade? Cidade { get; set; }

    }
}
