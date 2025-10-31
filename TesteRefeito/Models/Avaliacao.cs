using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteRefeito.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Nota { get; set; }
        [Required]
        [StringLength(500)]
        public string Comentario { get; set; }
        [Required]
        public int FilmeId { get; set; }
        [ForeignKey("FilmeId")]
        public Filme Filmes { get; set; }
    }
}
