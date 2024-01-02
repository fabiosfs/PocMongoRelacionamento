using AutoMapper;
using PocMongoRelacionamento.Domain.Commands;
using PocMongoRelacionamento.Domain.Dtos;
using PocMongoRelacionamento.Domain.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using PocMongoRelacionamento.Domain.Handlers.PessoaContext;
using PocMongoRelacionamento.Domain.Handlers.CategoriaContext;

namespace PocMongoRelacionamento.Domain
{
    public static class Setup
    {
        public static void DependenciasDomain(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PessoaMapper>();
                cfg.AddProfile<CategoriaMapper>();
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IRequestHandler<CriarPessoaCommand, RetornoPessoaDto>, CriarPessoaHandler>();
            services.AddScoped<IRequestHandler<CriarCategoriaCommand, RetornoCategoriaDto>, CriarCategoriaHandler>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
