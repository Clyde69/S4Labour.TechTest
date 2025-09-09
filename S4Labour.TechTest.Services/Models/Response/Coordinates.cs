using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Coordinates
	{
		[JsonProperty("latitude")]
		public string Latitude { get; set; }
		[JsonProperty("longitude")]
		public string Longitude { get; set; }
	}
}
