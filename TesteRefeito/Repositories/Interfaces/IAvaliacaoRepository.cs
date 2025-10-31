using TesteRefeito.Models;

namespace TesteRefeito.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task AdicionarAvaliacao(Avaliacao avaliacao);
        Task AlterarInformacaoAvaliacao(Avaliacao avaliacao);
        Task RemoverAvaliacao(int id);
        Task<Avaliacao> ObterAvaliacaoPorId(int id);
        Task<List<Avaliacao>> ObterTodasAvaliacoes();
    }
}
