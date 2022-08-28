namespace EncryptionService.API.Endpoints;

public static class EncryptEndpoint {
	public static RouteHandlerBuilder MapEncryptEndpoint(this WebApplication app, string url) =>
		app.MapPost(url, async ([FromBody] EncryptRequest request, [FromServices] IMediator mediator) => {
				if(!MiniValidator.TryValidate(request, out var errors)) {
					return Results.ValidationProblem(errors);
				}

				var response = await mediator.Send(new EncryptCommand(request));

				return Results.Ok(response);
			}).Produces(200, typeof(EncryptResponse))
			.ProducesValidationProblem()
			.WithMetadata(new SwaggerOperationAttribute("Encrypt", "Encrypt the provided value"));
}