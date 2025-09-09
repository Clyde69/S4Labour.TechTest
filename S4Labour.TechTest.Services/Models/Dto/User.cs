using S4Labour.TechTest.Services.Models.Response;

namespace S4Labour.TechTest.Services.Models.Dto
{
	public record User(string Title, string FirstName, string LastName, DateOnly DateOfBirth, int Age, 
		string EmailAddress, string UserName, DateOnly AccountRegistered, int AccountAge,
		Address Address, Picture Picture, Timezone Timezone)
	{
		public bool Favourite { get; set; } = false;
	}
}
