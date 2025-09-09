using S4Labour.TechTest.Services.Models.Dto;

namespace S4Labour.TechTest.Services
{
	internal class UserStorageService : IUserStorageService
	{
		public List<string> FavouriteUsers { get; set; } = new List<string>();
		public List<User> AllUsers { get; set; } = new List<User>();
		public List<UserNote> Notes { get; set; } = new List<UserNote>();
	}
}
