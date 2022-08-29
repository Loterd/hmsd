namespace EncryptionService.API.Endpoints;

public static class DecryptEndpoint {
	public static RouteHandlerBuilder MapDecryptEndpoint(this WebApplication app, string url) =>
		app.MapPost(url, async ([FromBody] DecryptRequest request, [FromServices] IMediator mediator) => {
				if(!MiniValidator.TryValidate(request, out var errors)) {
					return Results.ValidationProblem(errors);
				}

				var response = await mediator.Send(new DecryptCommand(request));

				if(response == null) {
					return Results.BadRequest($"Provided text '{request.TextToDecrypt}' cannot be decrypted. It could be encrypted with key which is deprecated");
				}

				return Results.Ok(response);
			}).Produces(200, typeof(DecryptResponse))
			.ProducesValidationProblem()
			.WithMetadata(new SwaggerOperationAttribute("Decrypt", "Decrypt the provided value"));
}