namespace EncryptionService.API.Handlers;

public class DecryptHandler : IRequestHandler<DecryptCommand, DecryptResponse> {
	private readonly IEncryptionService _encryptionService;
	private readonly IEncryptionKeyRepository _encryptionKeyRepository;

	public DecryptHandler(IEncryptionService encryptionService, IEncryptionKeyRepository encryptionKeyRepository) {
		_encryptionService = encryptionService;
		_encryptionKeyRepository = encryptionKeyRepository;
	}

	public async Task<DecryptResponse> Handle(DecryptCommand request, CancellationToken cancellationToken) {
		var keys = await _encryptionKeyRepository.GetLast(AppConfig.LastKeyQuantityUseToDecrypt);

		DecryptResponse response = null;
		foreach(var key in keys) {
			try {
				var result = _encryptionService.DecryptString(key.Key, request.Request.TextToDecrypt);
				response = new DecryptResponse { DecryptedText = result };
				break;
			} catch {
			}
		}

		return response;
	}
}