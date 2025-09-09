using F3R4L.DevPack.Api.Endpoints;
using S4Labour.TechTest.Services.Models.Response;

namespace S4Labour.TechTest.Services.Endpoints
{
	public class UserListEndpoint : GetEndpoint<UserList>
	{
		private const string _endpoint = "/api/";

		internal UserListEndpoint(string hostName) : base(hostName, _endpoint)
		{
		}
	}
}
