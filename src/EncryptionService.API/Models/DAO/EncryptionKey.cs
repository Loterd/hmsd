namespace EncryptionService.API.Models.DAO;

public class EncryptionKey {
	public Guid Id { get; set; }
	public string Key { get; set; }
	public DateTime AddedOn { get; set; }
}