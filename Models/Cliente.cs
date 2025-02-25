using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obrasoft.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int NrDocumento { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public int Numero { get; set; }
        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public Estado? Estado { get; set; }
        public Cidade? Cidade { get; set; }

    }
}
