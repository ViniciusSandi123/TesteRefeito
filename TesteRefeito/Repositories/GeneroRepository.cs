using Microsoft.EntityFrameworkCore;
using TesteRefeito.Data;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;

namespace TesteRefeito.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly Context _context;
        public GeneroRepository(Context context)
        {
            _context = context;
        }

        public async Task AdicionarGenero(Genero genero)
        {
            _context.Add(genero);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarInformacaoGenero(Genero genero)
        {
            _context.Update(genero);
            await _context.SaveChangesAsync();
        }

        public async Task<Genero> BuscarGeneroPorId(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                throw new KeyNotFoundException("Gênero não encontrado");
            }
            return genero;
        }

        public async Task<List<Genero>> ListarGeneros()
        {
            List<Genero> generos = await _context.Generos.ToListAsync();
            if(generos == null || generos.Count == 0)
            {
                throw new KeyNotFoundException("Nenhum gênero encontrado");
            }
            return generos;
        }

        public async Task RemoverGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }
    }
}
