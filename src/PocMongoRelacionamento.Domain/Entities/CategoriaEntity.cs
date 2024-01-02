using MongoDB.Bson.Serialization.Attributes;

namespace PocMongoRelacionamento.Domain.Entities
{
    public class CategoriaEntity : BaseEntity
    {
        public Guid IdPessoa { get; private set; }
        [BsonIgnore]
        public PessoaEntity Pessoa { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public CategoriaEntity(Guid idPessoa, string nome, string descricao)
            : base(Guid.NewGuid())
        {
            IdPessoa = idPessoa;
            Nome = nome;
            Descricao = descricao;
        }

        public CategoriaEntity(Guid id, Guid idPessoa, string nome, string descricao, DateTimeOffset dataCriacao, DateTimeOffset dataAtualizacao, PessoaEntity pessoa = null)
            : base(id, dataCriacao, dataAtualizacao)
        {
            IdPessoa = idPessoa;
            Pessoa = pessoa;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
