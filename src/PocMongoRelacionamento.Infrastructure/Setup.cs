using PocMongoRelacionamento.Domain.Interfaces;
using PocMongoRelacionamento.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace PocMongoRelacionamento.Infrastructure
{
    public static class Setup
    {
        public static void DependenciasInfrastructure(this IServiceCollection services, DataBaseConfiguration dataBaseConfiguration)
        {
            // Repositories Injections
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            // Configuração do mongo db
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(dataBaseConfiguration.ConnectionString));
            if (dataBaseConfiguration.IsSSL)
            {
                settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            }
            var client = new MongoClient(settings);
            var database = client.GetDatabase(dataBaseConfiguration.DatabaseName);
            services.AddSingleton(database);
        }
    }
}
