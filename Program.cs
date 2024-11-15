using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();

app.UseHttpMetrics(); //para monitorar as requisições HTTP, exportando métricas para o Prometheus

app.MapControllers();
app.MapMetrics(); //para exportar as métricas do Prometheus

app.Run();