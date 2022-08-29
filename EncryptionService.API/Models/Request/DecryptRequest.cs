namespace EncryptionService.API.Models.Request;

public class DecryptRequest : IValidatableObject {
	[Required] public string TextToDecrypt { get; set; }

	public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
		if(!Functions.IsBase64String(TextToDecrypt)) {
			yield return new ValidationResult("Provided text to decrypt should be in base64 encoding");
		}
	}
}