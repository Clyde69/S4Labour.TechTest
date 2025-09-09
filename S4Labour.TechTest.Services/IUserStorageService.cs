using S4Labour.TechTest.Services.Models.Dto;

namespace S4Labour.TechTest.Services
{
	public interface IUserStorageService
	{
		List<User> AllUsers { get; set; }
		List<string> FavouriteUsers { get; set; }
		List<UserNote> Notes { get; set; }
	}
}