using F3R4L.DevPack.Api.Services;
using Microsoft.Extensions.Options;
using S4Labour.TechTest.Services.Endpoints;
using S4Labour.TechTest.Services.Endpoints.Options;
using S4Labour.TechTest.Services.Extensions;
using S4Labour.TechTest.Services.Models.Dto;

namespace S4Labour.TechTest.Services
{
	public class RandomUserService : IRandomUserService
	{
		private readonly IApiService _apiService;
		private readonly RemoteUrlOptions _options;

		public RandomUserService(IApiService apiService, IOptions<RemoteUrlOptions> options)
		{
			_apiService = apiService;
			_options = options.Value;
		}

		public async Task<UserResults> GetAllUsersAsync()
		{
			var endpoint = new UserListEndpoint(_options.UserApi);
			var users = await _apiService.GetAsync(endpoint);

			return await users.UserListToUserResultsAsync();
		}
	}
}
