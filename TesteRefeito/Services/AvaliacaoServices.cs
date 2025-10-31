using AutoMapper;
using TesteRefeito.DTOs;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Services
{
    public class AvaliacaoServices : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IMapper _mapper;
        public AvaliacaoServices(IAvaliacaoRepository avaliacaoRepository, IMapper mapper)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _mapper = mapper;
        }
        public async Task AdicionarAvaliacao(AvaliacaoDTO avaliacaoDTO)
        {
            var avaliacao = _mapper.Map<Avaliacao>(avaliacaoDTO);
            await _avaliacaoRepository.AdicionarAvaliacao(avaliacao);
        }

        public async Task EditarAvaliacao(int id, AvaliacaoDTO avaliacaoDTO)
        {
            var resultado = await _avaliacaoRepository.ObterAvaliacaoPorId(id);
            var avaliacao = _mapper.Map(avaliacaoDTO, resultado);
            await _avaliacaoRepository.AlterarInformacaoAvaliacao(avaliacao);
        }

        public async Task ExcluirAvaliacao(int id)
        {
            var retorno = await _avaliacaoRepository.ObterAvaliacaoPorId(id);
            await _avaliacaoRepository.RemoverAvaliacao(id);
        }

        public async Task<AvaliacaoDTO> ObterAvaliacaoPorId(int id)
        {
            var retorno = await _avaliacaoRepository.ObterAvaliacaoPorId(id);
            var avaliacao = _mapper.Map<AvaliacaoDTO>(retorno);
            return avaliacao;
        }

        public async Task<List<AvaliacaoDTO>> ObterTodasAvaliacoes()
        {
            var retorno = await _avaliacaoRepository.ObterTodasAvaliacoes();
            var avaliacoes = _mapper.Map<List<AvaliacaoDTO>>(retorno);
            return avaliacoes;
        }
    }
}
