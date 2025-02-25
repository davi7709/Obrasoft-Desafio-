namespace Obrasoft.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string? Nome_Est { get; set; }
        public ICollection<Cidade>? Cidades { get; set; }
    }
}
