using Microsoft.EntityFrameworkCore;
using TesteRefeito.Data;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;

namespace TesteRefeito.Repositories
{
    public class FilmesRepository : IFilmeRepository
    {
        private readonly Context _context;

        public FilmesRepository(Context context)
        {
            _context = context;
        }

        public async Task AdicionarFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarInformacaoFilme(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<Filme> BuscarFilmePorId(int id)
        {
            var filme = await _context.Filmes
                .Include(f => f.Streaming)
                .Include(f => f.Genero)
                .FirstOrDefaultAsync(f => f.Id == id);

            if(filme == null)
            {
                throw new KeyNotFoundException("Filme não encontrado.");
            }
            return filme;
        }

        public async Task<List<Filme>> ListarFilmes()
        {
            List<Filme> filmes = await _context.Filmes
                .Include(f => f.Genero)
                .Include(f => f.Streaming)
                .ToListAsync();
            if (filmes == null || filmes.Count() == 0)
            {
                throw new Exception("Nenhum filme cadastrado.");
            }
            return filmes;

        }

        public async Task RemoverFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme != null)
            {
                _context.Filmes.Remove(filme);
                await _context.SaveChangesAsync();
            }
        }
    }
}
