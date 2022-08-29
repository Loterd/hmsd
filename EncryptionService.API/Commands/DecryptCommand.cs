namespace EncryptionService.API.Commands; 

public class DecryptCommand : IRequest<DecryptResponse> {
	public DecryptCommand(DecryptRequest request) {
		Request = request;
	}

	public DecryptRequest Request { get; set; }
}