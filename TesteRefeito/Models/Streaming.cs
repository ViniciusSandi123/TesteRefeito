using System.ComponentModel.DataAnnotations;

namespace TesteRefeito.Models
{
    public class Streaming
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<Filme> Filmes { get; set; }
    }
}
