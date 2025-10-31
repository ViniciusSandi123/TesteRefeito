using TesteRefeito.DTOs;

namespace TesteRefeito.Services.Interfaces
{
    public interface IFilmesService
    {
        Task AdicionarFilme(FilmeDTO filmeDTO);
        Task EditarFilme(int id, FilmeDTO filmeDTO);
        Task ExcluirFilme(int id);
        Task<FilmeDTO> ObterFilmePorId(int id);
        Task<List<FilmeDTO>> ObterTodosFilmes();
    }
}
