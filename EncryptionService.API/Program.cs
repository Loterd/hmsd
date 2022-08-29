var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => {
	x.EnableAnnotations();
});

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMemoryCache();
builder.Services.AddResponseCompression(options => {
	options.EnableForHttps = true;
});

builder.Services.AddSingleton<IEncryptionService, EncryptionAesService>();
builder.Services.AddSingleton<IEncryptionKeyRepository, EncryptionKeyRepositoryInMemory>();

builder.Services.AddHealthChecks();

var app = builder.Build();
app.UseHealthChecks("/healthz");
app.UseHttpsRedirection();
app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	
}

app.MapEncryptEndpoint("api/encrypt");
app.MapDecryptEndpoint("api/decrypt");
app.MapKeyRotateEndpoint("api/rotate-key");

app.MapGet("/", () => "Hello from EncryptionService.API!");

app.Run();