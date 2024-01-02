using AutoMapper;
using PocMongoRelacionamento.Domain.Commands;
using PocMongoRelacionamento.Domain.Dtos;
using PocMongoRelacionamento.Domain.Entities;

namespace PocMongoRelacionamento.Domain.Mappers
{
    public class PessoaMapper : Profile
    {
        public PessoaMapper()
        {
            CreateMap<CriarPessoaCommand, PessoaDto>()
                .ReverseMap();
            CreateMap<CriarPessoaCommand, PessoaEntity>()
                .ReverseMap();
            CreateMap<PessoaDto, PessoaEntity>()
                .ReverseMap(); 
            CreateMap<RetornoPessoaDto, PessoaEntity>()
                .ReverseMap();
        }
    }
}
