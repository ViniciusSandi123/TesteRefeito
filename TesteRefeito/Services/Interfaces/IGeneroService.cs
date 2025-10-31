using TesteRefeito.DTOs;

namespace TesteRefeito.Services.Interfaces
{
    public interface IGeneroService
    {
        Task AdicionarGenero(GeneroDTO generoDTO);
        Task EditarGenero(int id, GeneroDTO generoDTO);
        Task ExcluirGenero(int id);
        Task<GeneroDTO> ObterGeneroPorId(int id);
        Task<List<GeneroDTO>> ObterTodosGeneros();
    }
}
