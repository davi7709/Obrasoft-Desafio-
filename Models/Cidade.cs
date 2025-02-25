using System.Text.Json.Serialization;

namespace Obrasoft.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string? Nome_Cid { get; set; }
        public int EstadoId { get; set; }
        [JsonIgnore]
        public Estado? Estado { get; set; }

    }
}
