using Microsoft.EntityFrameworkCore;
using TesteRefeito.Data;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;

namespace TesteRefeito.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly Context _context;
        public AvaliacaoRepository(Context context)
        {
            _context = context;
        }

        public async Task AdicionarAvaliacao(Avaliacao avaliacao)
        {
            _context.Add(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarInformacaoAvaliacao(Avaliacao avaliacao)
        {
            _context.Update(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Avaliacao> ObterAvaliacaoPorId(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                throw new KeyNotFoundException("Avaliação não encontrada");
            }
            return avaliacao;
        }

        public async Task<List<Avaliacao>> ObterTodasAvaliacoes()
        {
            List<Avaliacao> avaliacoes = await _context.Avaliacoes.ToListAsync();
            if (avaliacoes == null || avaliacoes.Count == 0)
            {
                throw new KeyNotFoundException("Nenhuma avaliação encontrada");
            }
            return avaliacoes;
        }

        public async Task RemoverAvaliacao(int id)
        {
            var avaliacao = _context.Avaliacoes.Find(id);

            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
