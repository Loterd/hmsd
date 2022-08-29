namespace EncryptionService.API.Config; 

public static class AppConfig {
	public static readonly int LastKeyQuantityUseToDecrypt = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LAST_KEY_QUANTITY_USE_TO_DECRYPT"))
		? int.Parse(Environment.GetEnvironmentVariable("LAST_KEY_QUANTITY_USE_TO_DECRYPT")) : 5;
	
	public static readonly int KeyLength = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("KEY_LENGTH"))
		? int.Parse(Environment.GetEnvironmentVariable("KEY_LENGTH")) : 16;
}