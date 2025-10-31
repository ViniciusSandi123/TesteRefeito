using AutoMapper;
using TesteRefeito.DTOs;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Services
{
    public class StreamingServices : IStreamingService
    {
        private readonly IStreamingRepository _streamingRepository;
        private readonly IMapper _mapper;
        public StreamingServices(IStreamingRepository streamingRepository, IMapper mapper)
        {
            _streamingRepository = streamingRepository;
            _mapper = mapper;
        }
        public async Task AdcionarStreaming(StreamingDTO streamingDTO)
        {
            var streaming = _mapper.Map<Streaming>(streamingDTO);
            await _streamingRepository.AdicionarStreaming(streaming);
        }

        public async Task EditarStreaming(int id, StreamingDTO streamingDTO)
        {
            var retorno = await _streamingRepository.BuscarStreamingPorId(id);
            var streaming = _mapper.Map(streamingDTO, retorno);
            await _streamingRepository.AlterarInformacaoStreaming(streaming);
        }

        public async Task ExcluirStreaming(int id)
        {
            var streaming = await _streamingRepository.BuscarStreamingPorId(id);
            await _streamingRepository.RemoverStreaming(id);
        }

        public async Task<StreamingDTO> ObterStreamingPorId(int id)
        {
            var streaming = await _streamingRepository.BuscarStreamingPorId(id);
            var streamingDTO = _mapper.Map<StreamingDTO>(streaming);
            return streamingDTO;
        }

        public async Task<List<StreamingDTO>> ObterTodosStreamings()
        {
            var retorno =  await _streamingRepository.ListarStreamings();
            var streamings = _mapper.Map<List<StreamingDTO>>(retorno);
            return streamings;

        }
    }
}
