using AutoMapper;
using TesteRefeito.DTOs;
using TesteRefeito.Helpers;
using TesteRefeito.Models;

namespace TesteRefeito.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Filme, FilmeDTO>()
                .ForMember(dest => dest.Diretor, opt => opt.MapFrom(src => src.Diretor))
                .ForMember(dest => dest.Duracao, opt => opt.MapFrom(src => src.Duracao))
                .ForMember(dest => dest.FaixaEtaria, opt => opt.MapFrom(src => src.FaixaEtaria))
                .ForMember(dest => dest.FaixaEtariaDescricao, 
                    opt => opt.MapFrom(src => DescricaoEnum.EnumDecricao(src.FaixaEtaria)))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
                .ForMember(dest => dest.MesLancamento, opt => opt.MapFrom(src => src.MesLancamento))
                .ForMember(dest => dest.MesLancamentoDescricao,
                    opt => opt.MapFrom(src => DescricaoEnum.EnumDecricao(src.MesLancamento)))
                .ForMember(dest => dest.AnoLancamento, opt => opt.MapFrom(src => src.AnoLancamento))
                .ForMember(dest => dest.Generos, opt => opt.MapFrom(src => src.Genero.Select(g => g.Id).ToList()))
                .ForMember(dest => dest.GenerosNomes, opt => opt.MapFrom(src => src.Genero.Select(g => g.Nome).ToList()))
                .ForMember(dest => dest.Streamings, opt => opt.MapFrom(src => src.Streaming.Select(s => s.Id).ToList()))
                .ForMember(dest => dest.StreamingsNomes, opt => opt.MapFrom(src => src.Streaming.Select(s => s.Nome).ToList()));

            CreateMap<FilmeDTO, Filme>()
                .ForMember(dest => dest.Genero, opt => opt.Ignore())
                .ForMember(dest => dest.Streaming, opt => opt.Ignore());

            CreateMap<Genero, GeneroDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<GeneroDTO, Genero>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Streaming, StreamingDTO>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<StreamingDTO, Streaming>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Avaliacao, AvaliacaoDTO>()
                .ForMember(dest => dest.Nota, opt => opt.MapFrom(src => src.Nota))
                .ForMember(dest => dest.Comentario, opt => opt.MapFrom(src => src.Comentario))
                .ForMember(dest => dest.FilmeId, opt => opt.MapFrom(src => src.FilmeId));

            CreateMap<AvaliacaoDTO, Avaliacao>()
                .ForMember(dest => dest.Nota, opt => opt.MapFrom(src => src.Nota))
                .ForMember(dest => dest.Comentario, opt => opt.MapFrom(src => src.Comentario))
                .ForMember(dest => dest.FilmeId, opt => opt.MapFrom(src => src.FilmeId));
        }
    }
}
