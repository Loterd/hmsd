namespace EncryptionService.API.Endpoints;

public static class KeyRotateEndpoint {
	public static RouteHandlerBuilder MapKeyRotateEndpoint(this WebApplication app, string url) =>
		app.MapPost(url, async ([FromServices] IEncryptionKeyRepository repository) => {
			await repository.Add(Helpers.Functions.RandomString(AppConfig.KeyLength));
			return Results.Ok();
		}).Produces(200).WithMetadata(new SwaggerOperationAttribute("KeyRotate", "Create a new encryption key"));
}