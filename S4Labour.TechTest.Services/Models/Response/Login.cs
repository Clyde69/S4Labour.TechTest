using Newtonsoft.Json;

namespace S4Labour.TechTest.Services.Models.Response
{
	public record Login
	{
		[JsonProperty("uuid")]
		public string Uuid { get; set; }
		[JsonProperty("username")]
		public string UserName { get; set; }
		[JsonProperty("password")]
		public string Password { get; set; }
		[JsonProperty("salt")]
		public string Salt { get; set; }
		[JsonProperty("md5")]
		public string MD5 { get; set; }
		[JsonProperty("sha1")]
		public string SHA1 { get; set; }
		[JsonProperty("sha256")]
		public string SHA256 { get; set; }
	}
}
