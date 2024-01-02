using PocMongoRelacionamento.Domain.Commands;
using PocMongoRelacionamento.Domain.Dtos;
using PocMongoRelacionamento.Domain.Interfaces;
using MediatR;
using PocMongoRelacionamento.Domain.Entities;
using AutoMapper;

namespace PocMongoRelacionamento.Domain.Handlers.PessoaContext
{
    public class CriarPessoaHandler : IRequestHandler<CriarPessoaCommand, RetornoPessoaDto>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public CriarPessoaHandler(IPessoaRepository repository, IMapper mapper)
        {
            _pessoaRepository = repository;
            _mapper = mapper;
        }

        public async Task<RetornoPessoaDto> Handle(CriarPessoaCommand request, CancellationToken cancellationToken)
        {
            var entidade = _mapper.Map<PessoaEntity>(request);
            await _pessoaRepository.InsertAsync(entidade, cancellationToken);
            return _mapper.Map<RetornoPessoaDto>(entidade);
        }
    }
}
