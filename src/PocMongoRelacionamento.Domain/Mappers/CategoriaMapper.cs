using AutoMapper;
using PocMongoRelacionamento.Domain.Commands;
using PocMongoRelacionamento.Domain.Dtos;
using PocMongoRelacionamento.Domain.Entities;

namespace PocMongoRelacionamento.Domain.Mappers
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<CategoriaDto, CriarCategoriaCommand>();
            CreateMap<CriarCategoriaCommand, CategoriaEntity>();
            CreateMap<CategoriaEntity, RetornoCategoriaDto>();
        }
    }
}
