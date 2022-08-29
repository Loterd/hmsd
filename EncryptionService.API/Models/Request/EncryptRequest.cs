namespace EncryptionService.API.Models.Request; 

public class EncryptRequest {
	[Required]
	public string TextToEncrypt { get; set; }
}