using Gamax.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.ResetDatabaseAsync();

app.Run();
