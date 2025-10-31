using Microsoft.EntityFrameworkCore;
using TesteRefeito.Data;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;

namespace TesteRefeito.Repositories
{
    public class StreamingRepository : IStreamingRepository
    {
        private readonly Context _context;
        public StreamingRepository(Context context)
        {
            _context = context;
        }

        public async Task AdicionarStreaming(Streaming streaming)
        {
            _context.Add(streaming);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarInformacaoStreaming(Streaming streaming)
        {
            _context.Update(streaming);
            await _context.SaveChangesAsync();
        }

        public async Task<Streaming> BuscarStreamingPorId(int id)
        {
            var streaming = await _context.Streamings.FindAsync(id);
            if(streaming == null)
            {
                throw new KeyNotFoundException("Streaming não encontrado");
            }
            return streaming;
        }

        public async Task<List<Streaming>> ListarStreamings()
        {
            List<Streaming> streamings = await _context.Streamings.ToListAsync();
            if (streamings == null || streamings.Count == 0)
            {
                throw new KeyNotFoundException("Nenhum streaming encontrado");
            }
            return streamings;
        }

        public async Task RemoverStreaming(int id)
        {
            var streaming = await _context.Streamings.FindAsync(id);
            if (streaming != null)
            {
                _context.Streamings.Remove(streaming);
                await _context.SaveChangesAsync();
            }
        }
    }
}
