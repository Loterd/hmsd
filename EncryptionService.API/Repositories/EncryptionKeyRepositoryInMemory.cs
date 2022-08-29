namespace EncryptionService.API.Repositories; 

public class EncryptionKeyRepositoryInMemory : IEncryptionKeyRepository {
	private readonly IMemoryCache _memoryCache;
	private readonly SemaphoreSlim _cacheLock = new(1);
	private const string CacheKey = "_EncryptionKey";

	public EncryptionKeyRepositoryInMemory(IMemoryCache memoryCache) {
		_memoryCache = memoryCache;
		
		//seed data
		var newKeys = new List<EncryptionKey> {
			new() {
				Id = Guid.NewGuid(),
				Key = Helpers.Functions.RandomString(AppConfig.KeyLength),
				AddedOn = DateTime.UtcNow
			}
		};
		_memoryCache.Set(CacheKey, newKeys);
	}

	public Task Add(string key) {
		_cacheLock.Wait();

		var keyToAdd = new EncryptionKey { Id = Guid.NewGuid(), Key = key, AddedOn = DateTime.UtcNow };
		
		if(_memoryCache.TryGetValue<IList<EncryptionKey>>(CacheKey, out var keys)) {
			keys.Add(keyToAdd);
		} else {
			var newKeys = new List<EncryptionKey>();
			newKeys.Add(keyToAdd);
			_memoryCache.Set(CacheKey, newKeys);
		}

		_cacheLock.Release();

		return Task.CompletedTask;
	}

	public Task<List<EncryptionKey>> GetLast(int lastQuantity) {
		_cacheLock.Wait();

		var keysToReturn = new List<EncryptionKey>();
		if(_memoryCache.TryGetValue<IList<EncryptionKey>>(CacheKey, out var keys)) {
			keysToReturn = keys.OrderByDescending(t => t.AddedOn).Take(lastQuantity).ToList();
		} else {
			throw new Exception("No any keys");
		}
		
		_cacheLock.Release();

		return Task.FromResult(keysToReturn);
	}
}