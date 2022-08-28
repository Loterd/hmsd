namespace EncryptionService.API.Repositories; 

public interface IEncryptionKeyRepository {
	Task Add(string key);
	Task<IEnumerable<EncryptionKey>> GetLast(int lastNumber);
}