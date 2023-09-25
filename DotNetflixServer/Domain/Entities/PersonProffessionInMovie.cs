namespace Domain.Entities;

public class PersonProffessionInMovie
{
	public int PersonId { get; set; }
	public Person Person { get; set; } = null!;
	public int MovieInfoId { get; set; }
    public int ProfessionId { get; set; }
    public Profession Profession { get; set; } = null!;
}