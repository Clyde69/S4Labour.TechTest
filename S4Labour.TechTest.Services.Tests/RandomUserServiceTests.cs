using AutoFixture;
using F3R4L.DevPack.Api.Services;
using Microsoft.Extensions.Options;
using Moq;
using S4Labour.TechTest.Services.Endpoints;
using S4Labour.TechTest.Services.Endpoints.Options;
using S4Labour.TechTest.Services.Models.Dto;
using S4Labour.TechTest.Services.Models.Response;

namespace S4Labour.TechTest.Services.Tests
{
	public class Tests
	{
		private RandomUserService _objectUnderTest;

		private Mock<IApiService> _apiService;
		private Mock<IOptions<RemoteUrlOptions>> _options;

		private Fixture _fixture;

		[SetUp]
		public void Setup()
		{
			_apiService = new Mock<IApiService>();
			_options = new Mock<IOptions<RemoteUrlOptions>>();

			_options.Setup(s => s.Value)
				.Returns(new RemoteUrlOptions());

			_objectUnderTest = new RandomUserService(_apiService.Object, _options.Object);

			_fixture = new Fixture();
		}

		[Test]
		public async Task Test1Async()
		{
			//	Arrange
			var coords = new Models.Response.Coordinates
			{
				Latitude = "0",
				Longitude = "0"
			};
			var userResults = _fixture.Build<Models.Response.User>()
				.CreateMany(3).ToArray();

			foreach(var item in userResults)
			{
				item.Location.Coordinates = coords;
			}

			var apiResultList = _fixture.Build<UserList>()
				.With(w => w.Results, userResults)
				.Create();
			_apiService.Setup(s => s.GetAsync(It.IsAny<UserListEndpoint>()))
				.ReturnsAsync(apiResultList);

			//	Act
			var results = await _objectUnderTest.GetAllUsersAsync();

			//	Assert
			_apiService.Verify(v => v.GetAsync(It.IsAny<UserListEndpoint>()), Times.Once);
			Assert.IsTrue(results.Users.Count() == 3);

			for (var i = 0; i < 3; i++)
			{
				Assert.IsTrue(results.Users.ElementAt(i).UserName == userResults[i].Login.UserName);
			}
		}
	}
}