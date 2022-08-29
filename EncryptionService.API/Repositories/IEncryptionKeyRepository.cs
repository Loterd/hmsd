namespace EncryptionService.API.Repositories; 

public interface IEncryptionKeyRepository {
	Task Add(string key);
	Task<List<EncryptionKey>> GetLast(int lastQuantity);
}