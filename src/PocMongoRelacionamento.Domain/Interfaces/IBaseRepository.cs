using System.Linq.Expressions;

namespace PocMongoRelacionamento.Domain.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancel);
        public Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> fillter, CancellationToken cancel);
        public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancel);
        public Task<TEntity> InsertAsync(TEntity data, CancellationToken cancel);
        public Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> data, CancellationToken cancel);
        public Task<TEntity> UpdateAsync(TEntity data, CancellationToken cancel);
        public Task<TEntity> DeleteAsync(Guid id, CancellationToken cancel);
    }
}
