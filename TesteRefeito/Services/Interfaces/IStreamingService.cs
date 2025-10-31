using TesteRefeito.DTOs;

namespace TesteRefeito.Services.Interfaces
{
    public interface IStreamingService
    {
        Task AdcionarStreaming(StreamingDTO streamingDTO);
        Task EditarStreaming(int id, StreamingDTO streamingDTO);
        Task ExcluirStreaming(int id);
        Task<StreamingDTO> ObterStreamingPorId(int id);
        Task<List<StreamingDTO>> ObterTodosStreamings();
    }
}
