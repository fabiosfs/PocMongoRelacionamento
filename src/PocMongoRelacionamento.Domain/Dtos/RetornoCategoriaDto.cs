namespace PocMongoRelacionamento.Domain.Dtos
{
    public class RetornoCategoriaDto
    {
        public Guid Id { get; set; }
        public PessoaDto Pessoa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
