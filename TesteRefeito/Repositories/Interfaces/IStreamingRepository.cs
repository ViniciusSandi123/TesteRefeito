using TesteRefeito.Models;

namespace TesteRefeito.Repositories.Interfaces
{
    public interface IStreamingRepository
    {
        Task AdicionarStreaming(Streaming streaming);
        Task AlterarInformacaoStreaming(Streaming streaming);
        Task<Streaming> BuscarStreamingPorId(int id);
        Task<List<Streaming>> ListarStreamings();
        Task RemoverStreaming(int id);
    }
}
