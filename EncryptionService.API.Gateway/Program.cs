var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(AppConfig.ConfigFile, optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHealthChecks("/healthz");

app.UseOcelot().Wait();

app.Run();