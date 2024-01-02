namespace PocMongoRelacionamento.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTimeOffset DataCriacao { get; private set; }
        public DateTimeOffset DataAtualizacao { get; private set; }

        public BaseEntity(Guid id)
        {
            Id = id;
            GerarDataCriacao();
            GerarDataAtualizacao();
        }

        public BaseEntity(Guid id, DateTimeOffset dataCriacao, DateTimeOffset dataAtualizacao)
        {
            Id = id;
            DataCriacao = dataCriacao;
            DataAtualizacao = dataAtualizacao;
        }

        public virtual void GerarId() { Id = Guid.NewGuid(); }
        
        public virtual void GerarDataCriacao() { DataCriacao = DateTimeOffset.Now; }
        
        public virtual void GerarDataAtualizacao() { DataAtualizacao = DateTime.Now; }
    }
}
