using PocMongoRelacionamento.Domain.Entities;
using PocMongoRelacionamento.Domain.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Threading.Channels;

namespace PocMongoRelacionamento.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected IMongoCollection<TEntity> _collection { get; set; }

        public BaseRepository(IMongoDatabase database)
        {

            _collection = database.GetCollection<TEntity>(CollectionName(), null);
        }

        protected string CollectionName(Type type = null)
        {
            if(type == null)
                return typeof(TEntity).Name.Replace("Entity", "");
            else
                return type.Name.Replace("Entity", "");
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancel)
            => (await _collection.FindAsync(x => true, null, cancel)).ToList();

        public virtual async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> fillter, CancellationToken cancel)
            => (await _collection.FindAsync(fillter, null, cancel)).ToList();

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancel) 
            => await _collection.Find(_ => _.Id == id).Limit(1).SingleAsync(cancel);

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancel)
        {
            entity.GerarId();
            entity.GerarDataCriacao();
            entity.GerarDataAtualizacao();
            await _collection.InsertOneAsync(entity, null, cancel);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancel)
        {
            entities.ToList().ForEach(entity =>
            {
                entity.GerarId();
                entity.GerarDataCriacao();
                entity.GerarDataAtualizacao();
            });
            await _collection.InsertManyAsync(entities, null, cancel);
            return entities;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancel)
        {
            var options = new ReplaceOptions();
            entity.GerarDataAtualizacao();
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, options, cancel);
            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id, CancellationToken cancel) => await _collection.FindOneAndDeleteAsync(x => x.Id == id, null, cancel);
    }
}
