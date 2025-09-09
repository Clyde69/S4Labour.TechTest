using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Info
	{
		[JsonProperty("seed")]
		public string Seed { get; set; }
		[JsonProperty("results")]
		public int Results { get; set; }
		[JsonProperty("page")]
		public int Page { get; set; }
		[JsonProperty("version")]
		public string Version { get; set; }
	}
}
