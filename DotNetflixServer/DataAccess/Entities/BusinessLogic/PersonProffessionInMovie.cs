namespace DataAccess.Entities.BusinessLogic;

public class PersonProffessionInMovie
{
	public int PersonId { get; set; }
	public int MovieInfoId { get; set; }
	public string Proffession { get; set; } // maxLength = 15
	public Person Person { get; set; }
}