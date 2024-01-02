using PocMongoRelacionamento.Infrastructure.Repositories;
using PocMongoRelacionamento.Infrastructure;
using PocMongoRelacionamento.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.DependenciasInfrastructure(new DataBaseConfiguration()
{
    ConnectionString = builder.Configuration.GetSection("PocMongoRelacionamentoConnection:ConnectionString").Value,
    DatabaseName = builder.Configuration.GetSection("PocMongoRelacionamentoConnection:DataBase").Value,
    IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("PocMongoRelacionamentoConnection:IsSSL").Value)
});
builder.Services.DependenciasDomain();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
