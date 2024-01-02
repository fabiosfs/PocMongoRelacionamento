using PocMongoRelacionamento.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PocMongoRelacionamento.Domain.Commands;
using AutoMapper;
using PocMongoRelacionamento.Domain.Interfaces;

namespace PocMongoRelacionamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PessoasController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RetornoPessoaDto>>> Get([FromServices] IPessoaRepository repository, CancellationToken cancel)
        {
            var retorno = await repository.ListAsync(cancel);
            return Ok(_mapper.Map<List<RetornoPessoaDto>>(retorno));
        }

        [HttpPost]
        public async Task<ActionResult<RetornoPessoaDto>> Post([FromBody] PessoaDto dto, CancellationToken cancel)
        {
            var comando = _mapper.Map<CriarPessoaCommand>(dto);
            var retorno = await _mediator.Send(comando, cancel);
            return Ok(retorno);
        }
    }
}