using ManipulacaoArquivos.Interfaces;
using ManipulacaoArquivos.Models;
using ManipulacaoArquivos.Repositories;
using ManipulacaoArquivos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ArquivosConfig>(builder.Configuration.GetSection("ArquivosConfig"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ManipulacaoArquivos API", Version = "v1" });
});

builder.Services.AddScoped<IArquivoService, ArquivoService>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManipulacaoArquivos API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
