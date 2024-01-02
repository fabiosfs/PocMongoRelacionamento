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
    public class CategoriasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoriasController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaDto>>> Get([FromServices] ICategoriaRepository repository, CancellationToken cancel)
        {
            var retorno = await repository.ListAsync(cancel);
            return Ok(_mapper.Map<List<RetornoCategoriaDto>>(retorno));
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> Post([FromBody] CategoriaDto dto, CancellationToken cancel)
        {
            var comando = _mapper.Map<CriarCategoriaCommand>(dto);
            var retorno = await _mediator.Send(comando, cancel);
            return Ok(retorno);
        }
    }
}