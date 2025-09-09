using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record User
	{
		[JsonProperty("gender")]
		public string Gender { get; set; }
		[JsonProperty("name")]
		public Name Name { get; set; }
		[JsonProperty("location")]
		public Location Location { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("login")]
		public Login Login { get; set; }
		[JsonProperty("dob")]
		public DateAndAge DateOfBirth { get; set; }
		[JsonProperty("Registered")]
		public DateAndAge Registered { get; set; }
		[JsonProperty("phone")]
		public string Phone { get; set; }
		[JsonProperty("cell")]
		public string Cellphone { get; set; }
		[JsonProperty("id")]
		public Id Id { get; set; }
		[JsonProperty("picture")]
		public Picture Picture { get; set; }
		[JsonProperty("nat")]
		public string Nationality { get; set; }
	}
}
