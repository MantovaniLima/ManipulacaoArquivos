using ManipulacaoArquivos.Interfaces;
using ManipulacaoArquivos.Models;
using ManipulacaoArquivos.Repositories;
using ManipulacaoArquivos.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de ArquivosConfig a partir do arquivo de configura��o
builder.Services.Configure<ArquivosConfig>(builder.Configuration.GetSection("ArquivosConfig"));

// Adiciona suporte a controladores
builder.Services.AddControllers();

// Configura��o do Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ManipulacaoArquivos API", Version = "v1" });
});

// Inje��o de depend�ncias
builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();

var app = builder.Build();

// Configura��o do middleware para ambientes de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManipulacaoArquivos API v1"));
}

// Middleware para redirecionamento HTTPS e autoriza��o
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeamento de controladores
app.MapControllers();

// Execu��o da aplica��o
app.Run();