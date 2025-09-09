using Newtonsoft.Json;
using S4Labour.TechTest.Services.Models.Response;

namespace S4Labour.TechTest.Services.Models.Dto
{
	public record UserResults (int Count, int Page, string Version, IEnumerable<User> Users);
}
