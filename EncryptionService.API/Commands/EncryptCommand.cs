namespace EncryptionService.API.Commands; 

public class EncryptCommand : IRequest<EncryptResponse> {
	public EncryptCommand(EncryptRequest request) {
		Request = request;
	}

	public EncryptRequest Request { get; set; }
}