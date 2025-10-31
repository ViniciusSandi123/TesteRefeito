using TesteRefeito.DTOs;

namespace TesteRefeito.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task AdicionarAvaliacao(AvaliacaoDTO avaliacaoDTO);
        Task EditarAvaliacao(int id, AvaliacaoDTO avaliacaoDTO);
        Task ExcluirAvaliacao(int id);
        Task<AvaliacaoDTO> ObterAvaliacaoPorId(int id);
        Task<List<AvaliacaoDTO>> ObterTodasAvaliacoes();
    }
}
