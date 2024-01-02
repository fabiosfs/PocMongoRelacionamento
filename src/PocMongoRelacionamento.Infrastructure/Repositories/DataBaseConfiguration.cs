namespace PocMongoRelacionamento.Infrastructure.Repositories
{
    public class DataBaseConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
