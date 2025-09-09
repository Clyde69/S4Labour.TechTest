using S4Labour.TechTest.Services.Models.Dto;

namespace S4Labour.TechTest.Services
{
	public interface IRandomUserService
	{
		Task<UserResults> GetAllUsersAsync();
	}
}