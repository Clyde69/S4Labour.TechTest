using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record UserList
	{
		[JsonProperty("results")]
		public User[] Results { get; set; }
		[JsonProperty("info")]
		public Info Info { get; set; }
	}
}
