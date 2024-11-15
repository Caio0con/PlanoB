using Prometheus;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

//criar swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pedido", Version = "v1" });
});

var app = builder.Build();
app.UseRouting();
// Configure o middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedido");
    c.RoutePrefix = string.Empty; // Define o Swagger UI na raiz (opcional)
});

app.UseHttpMetrics(); //para monitorar as requisições HTTP, exportando métricas para o Prometheus
app.MapControllers();
app.MapMetrics(); //para exportar as métricas do Prometheus

app.Run();