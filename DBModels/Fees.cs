namespace DBModels
{
	public class Fees
	{
		public int Id { get; set; }
		public CurrencyValue? World { get; set; }
		public CurrencyValue? Russia { get; set; } 
		public CurrencyValue? USA { get; set; }
	}
}