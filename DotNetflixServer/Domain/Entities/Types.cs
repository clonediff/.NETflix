namespace Domain.Entities;

public class Types
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;   // maxLength = 20
	public string Slug { get; set; } = null!;   // maxLength = 20
}
