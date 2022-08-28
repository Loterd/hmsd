namespace EncryptionService.API.Services; 

public interface IEncryptionService {
	string EncryptString(string key, string plainText);
	string DecryptString(string key, string cipherText);
}