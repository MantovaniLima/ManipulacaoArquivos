using ManipulacaoArquivos.Interfaces;
using ManipulacaoArquivos.Models;
using ManipulacaoArquivos.Repositories;
using ManipulacaoArquivos.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração de ArquivosConfig a partir do arquivo de configuração
builder.Services.Configure<ArquivosConfig>(builder.Configuration.GetSection("ArquivosConfig"));

// Adiciona suporte a controladores
builder.Services.AddControllers();

// Configuração do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ManipulacaoArquivos API", Version = "v1" });
});

// Injeção de dependências
builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();

var app = builder.Build();

// Configuração do middleware para ambientes de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManipulacaoArquivos API v1"));
}

// Middleware para redirecionamento HTTPS e autorização
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento de controladores
app.MapControllers();

// Execução da aplicação
app.Run();