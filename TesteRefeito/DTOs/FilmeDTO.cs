using TesteRefeito.Helpers.Enums;

namespace TesteRefeito.DTOs
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        public string Diretor { get; set; }
        public int Duracao { get; set; }
        public eFaixaEtaria FaixaEtaria { get; set; }
        public string FaixaEtariaDescricao { get; set; }
        public string Titulo { get; set; }
        public eMes MesLancamento { get; set; }
        public string MesLancamentoDescricao { get; set; }
        public int AnoLancamento { get; set; }
        public List<int> Generos { get; set; }
        public List<string> GenerosNomes { get; set; }
        public List<int> Streamings { get; set; }
        public List<string> StreamingsNomes { get; set; }
    }
}
