namespace S4Labour.TechTest.Services.Models.Dto
{
	public record Address (int Number, string Street, string City, string State, string Country, 
		string PostCode, Coordinates Coordinates);
}
