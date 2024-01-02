using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PocMongoRelacionamento.Domain.Entities;
using PocMongoRelacionamento.Domain.Interfaces;

namespace PocMongoRelacionamento.Infrastructure.Repositories
{
    public class CategoriaRepository : BaseRepository<CategoriaEntity>, ICategoriaRepository
    {
        private readonly IMongoDatabase _database;
        public CategoriaRepository(IMongoDatabase database) : base(database)
        {
            _database = database;
        }

        public override async Task<IEnumerable<CategoriaEntity>> ListAsync(CancellationToken cancel)
        {
            var pessoaCollection = _database.GetCollection<PessoaEntity>(CollectionName(typeof(PessoaEntity)), null);
            
            var retorno = _collection.AsQueryable()
                .Where(x => true)
                .Join(
                    pessoaCollection.AsQueryable(),
                    categoria => categoria.IdPessoa,
                    pessoa => pessoa.Id,
                    (categoria, pessoa) => new CategoriaEntity(
                        categoria.Id,
                        categoria.IdPessoa,
                        categoria.Nome,
                        categoria.Descricao,
                        categoria.DataCriacao,
                        categoria.DataAtualizacao,
                        pessoa
                    )
                ).ToList();

            return retorno;
        }
    }
}
