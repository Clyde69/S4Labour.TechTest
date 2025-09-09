using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Street
	{
		[JsonProperty("number")]
		public int Number { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
