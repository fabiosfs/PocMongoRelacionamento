using PocMongoRelacionamento.Domain.Entities;
using PocMongoRelacionamento.Domain.Interfaces;
using MongoDB.Driver;

namespace PocMongoRelacionamento.Infrastructure.Repositories
{
    public class PessoaRepository : BaseRepository<PessoaEntity>, IPessoaRepository
    {
        public PessoaRepository(IMongoDatabase database) : base(database)
        {

        }
    }
}
