using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Location
	{
		[JsonProperty("street")]
		public Street Street { get; set; }
		[JsonProperty("city")]
		public string City { get; set; }
		[JsonProperty("state")]
		public string State { get; set; }
		[JsonProperty("country")]
		public string Country { get; set; }
		[JsonProperty("postcode")]
		public object Postcode { get; set; }
		[JsonProperty("coordinates")]
		public Coordinates Coordinates { get; set; }
		[JsonProperty("timezone")]
		public Timezone Timezone { get; set; }
	}
}
