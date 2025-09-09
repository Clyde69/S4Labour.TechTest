namespace S4Labour.TechTest.Services.Endpoints.Options
{
	public record RemoteUrlOptions
	{
		public const string ConfigurationSection = "RemoteUrls";

		public string UserApi { get; set; } = string.Empty;
	}
}
