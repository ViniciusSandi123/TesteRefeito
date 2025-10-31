using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteRefeito.Helpers.Enums;

namespace TesteRefeito.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Diretor { get; set; }
        [Required]
        public int Duracao { get; set; }
        [Required]
        public eFaixaEtaria FaixaEtaria { get; set; }
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        [Required]
        [Range(1, 12)]
        public eMes MesLancamento { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int AnoLancamento { get; set; }
        [Required]
        public ICollection<Genero> Genero { get; set; }
        public ICollection<Streaming> Streaming { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}