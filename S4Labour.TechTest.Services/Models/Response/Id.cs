using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Id
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
