namespace DBModels.BusinessLogic
{
	public class Person
	{
		public int Id { get; set; }
		public string? Photo { get; set; }
		public string Name { get; set; }    // maxLength = 50
		public List<PersonProffessionInMovie> Proffessions { get; set; }
	}
}