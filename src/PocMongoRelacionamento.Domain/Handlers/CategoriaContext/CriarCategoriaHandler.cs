using AutoMapper;
using MediatR;
using PocMongoRelacionamento.Domain.Commands;
using PocMongoRelacionamento.Domain.Dtos;
using PocMongoRelacionamento.Domain.Entities;
using PocMongoRelacionamento.Domain.Interfaces;

namespace PocMongoRelacionamento.Domain.Handlers.CategoriaContext
{
    public class CriarCategoriaHandler : IRequestHandler<CriarCategoriaCommand, RetornoCategoriaDto>
    {
        private readonly ICategoriaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public CriarCategoriaHandler(ICategoriaRepository repository, IMapper mapper)
        {
            _pessoaRepository = repository;
            _mapper = mapper;
        }

        public async Task<RetornoCategoriaDto> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var entidade = _mapper.Map<CategoriaEntity>(request);
            await _pessoaRepository.InsertAsync(entidade, cancellationToken);
            return _mapper.Map<RetornoCategoriaDto>(entidade);
        }
    }
}
