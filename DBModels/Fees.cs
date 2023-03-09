namespace DBModels
{
	public class Fees
	{
		public uint Id { get; set; }
		public CurrencyValue? World { get; set; }
		public CurrencyValue? Russia { get; set; }
		public CurrencyValue? USA { get; set; }
	}
}