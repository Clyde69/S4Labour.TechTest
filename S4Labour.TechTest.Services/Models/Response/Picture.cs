using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Picture
	{
		[JsonProperty("large")]
		public string Large { get; set; }
		[JsonProperty("medium")]
		public string Medium { get; set; }
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }
	}
}
