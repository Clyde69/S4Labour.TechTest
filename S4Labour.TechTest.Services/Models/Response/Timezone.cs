using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Timezone
	{
		[JsonProperty("offset")]
		public string UTC_Offset { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
	}
}
