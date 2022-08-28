var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression(options => {
	options.EnableForHttps = true;
});

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => "Hello from EncryptionService.API!");

app.Run();