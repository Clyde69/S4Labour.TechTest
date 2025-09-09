using S4Labour.TechTest.Services.Models.Dto;
using S4Labour.TechTest.Services.Models.Response;
using Input = S4Labour.TechTest.Services.Models.Response;
using Output = S4Labour.TechTest.Services.Models.Dto;

namespace S4Labour.TechTest.Services.Extensions
{
	internal static class MappingExtensions
	{
		internal static Task<UserResults> UserListToUserResultsAsync(this UserList userList)
		{
			return Task.Run(() => {
				var users = userList.Results.ToAsyncEnumerable().SelectAwait(async s =>
					await s.UserResponseToDto());

				var result = new UserResults(userList.Info.Page, userList.Info.Results,
					userList.Info.Version, users.ToEnumerable());

				return result;
			});
		}

		internal static async Task<Output.User> UserResponseToDto(this Input.User user)
		{
			var address = await user.AddressResponseToDto();

			var result = new Output.User(user.Name.Title, user.Name.FirstName, user.Name.LastName,
				DateOnly.FromDateTime(user.DateOfBirth.Date), user.DateOfBirth.Age, user.Email,
				user.Login.UserName, DateOnly.FromDateTime(user.Registered.Date), user.Registered.Age,
				address, user.Picture, user.Location.Timezone
			);

			return result;
		}

		internal static Task<Address> AddressResponseToDto(this Input.User user)
		{
			return Task.Run(() => {
				var coordinates = new Output.Coordinates(Convert.ToDecimal(user.Location.Coordinates.Latitude), Convert.ToDecimal(user.Location.Coordinates.Longitude));

				var result = new Address(user.Location.Street.Number, user.Location.Street.Name,
					user.Location.City, user.Location.State, user.Location.Country, user.Location.Postcode.ToString(),
					coordinates);

				return result;
			});
		}
	}
}
