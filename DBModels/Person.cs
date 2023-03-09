namespace DBModels
{
	public class Person
	{
		public uint Id { get; set; }
		public string? Photo { get; set; }
		public string Name { get; set; }
		public List<PersonProffessionInMovie> Proffessions { get; set; }
	}
}