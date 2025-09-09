using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Name
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("first")]
		public string FirstName { get; set; }
		[JsonProperty("last")]
		public string LastName { get; set; }
	}
}
