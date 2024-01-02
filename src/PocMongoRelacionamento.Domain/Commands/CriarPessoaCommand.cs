using PocMongoRelacionamento.Domain.Dtos;
using MediatR;

namespace PocMongoRelacionamento.Domain.Commands
{
    public class CriarPessoaCommand : PessoaDto, IRequest<RetornoPessoaDto>
    {

    }
}
