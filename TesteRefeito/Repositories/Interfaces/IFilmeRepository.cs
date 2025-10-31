using TesteRefeito.Models;

namespace TesteRefeito.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        Task AdicionarFilme(Filme filme);
        Task AlterarInformacaoFilme(Filme filme);
        Task<Filme> BuscarFilmePorId(int id);
        Task<List<Filme>> ListarFilmes();
        Task RemoverFilme(int id);
    }
}
