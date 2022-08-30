namespace EncryptionService.API.Gateaway.AppConfig; 

public static class AppConfig {
	public static readonly string ConfigFile = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("OCELOT_CONFIGURATION_FILE"))
		? Environment.GetEnvironmentVariable("OCELOT_CONFIGURATION_FILE") : "ocelot.json";
}