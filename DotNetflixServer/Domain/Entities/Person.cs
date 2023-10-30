namespace Domain.Entities;

public class Person
{
	public int Id { get; set; }
	public string? Photo { get; set; }
	public string Name { get; set; } = null!;    // maxLength = 50
	public List<PersonProffessionInMovie> Proffessions { get; set; } = null!;
}