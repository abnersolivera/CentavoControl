var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

#region Build

builder.Services.ConfigureServices(config);
builder.Services.ConfigureController();
builder.Services.ConfigureEndpoints();


#endregion

var app = builder.Build();

var appBuilder = (IApplicationBuilder)app;
var logger = appBuilder.ApplicationServices.GetRequiredService<ILogger<Program>>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.ConfigureSwagger();
logger.LogInformation("Mapping endpoint ...");
app.MapEndpoints(config);
logger.LogInformation("Configuring authorization ...");
app.UseAuthorization();
logger.LogInformation("Initializing server ...");
app.Run();


namespace CentavoControl
{
    /// <summary>
    /// Classe partial para configuração do Program (utilizado para testes de integração)
    /// </summary>
    public class Program { }
}