using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record DateAndAge
	{
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("age")]
		public int Age { get; set; }
	}
}
