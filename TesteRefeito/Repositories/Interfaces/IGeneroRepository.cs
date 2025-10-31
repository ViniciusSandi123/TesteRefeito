using TesteRefeito.Models;

namespace TesteRefeito.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task AdicionarGenero(Genero genero);
        Task AlterarInformacaoGenero(Genero genero);
        Task<List<Genero>> ListarGeneros();
        Task<Genero> BuscarGeneroPorId(int id);
        Task RemoverGenero(int id);
    }
}
