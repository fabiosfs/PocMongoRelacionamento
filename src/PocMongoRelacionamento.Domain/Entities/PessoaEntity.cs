namespace PocMongoRelacionamento.Domain.Entities
{
    public class PessoaEntity : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Documento { get; private set; }

        public PessoaEntity(string nome, string email, string senha, string documento)
            : base(Guid.NewGuid())
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Documento = documento;
        }

        public PessoaEntity(Guid id, string nome, string email, string senha, string documento, DateTimeOffset dataCriacao, DateTimeOffset dataAtualizacao) 
            : base(id, dataCriacao, dataAtualizacao)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Documento = documento;
        }
    }
}
