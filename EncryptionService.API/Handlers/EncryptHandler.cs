namespace EncryptionService.API.Handlers; 

public class EncryptHandler:IRequestHandler<EncryptCommand, EncryptResponse> {
	private readonly IEncryptionService _encryptionService;
	private readonly IEncryptionKeyRepository _encryptionKeyRepository;

	public EncryptHandler(IEncryptionService encryptionService, IEncryptionKeyRepository encryptionKeyRepository) {
		_encryptionService = encryptionService;
		_encryptionKeyRepository = encryptionKeyRepository;
	}

	public async Task<EncryptResponse> Handle(EncryptCommand request, CancellationToken cancellationToken) {
		var key = (await _encryptionKeyRepository.GetLast(1)).First();

		var encryptedText = _encryptionService.EncryptString(key.Key, request.Request.TextToEncrypt);

		return new EncryptResponse{EncryptedText = encryptedText};
	}
}