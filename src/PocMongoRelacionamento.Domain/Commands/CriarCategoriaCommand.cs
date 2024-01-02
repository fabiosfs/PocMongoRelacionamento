using PocMongoRelacionamento.Domain.Dtos;
using MediatR;

namespace PocMongoRelacionamento.Domain.Commands
{
    public class CriarCategoriaCommand : CategoriaDto, IRequest<RetornoCategoriaDto>
    {

    }
}
