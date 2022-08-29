namespace EncryptionService.API.Helpers;

public static class Functions {
	private static readonly Random Random = new Random();

	public static string RandomString(int length) {
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		return new string(Enumerable.Repeat(chars, length)
			.Select(s => s[Random.Next(s.Length)]).ToArray());
	}

	public static bool IsBase64String(string base64) {
		Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
		return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
	}
}