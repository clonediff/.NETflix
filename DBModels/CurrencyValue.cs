using System.ComponentModel.DataAnnotations;

namespace DBModels
{
	public class CurrencyValue
	{
		public int Id { get; set; }
		public uint Value { get; set; }
		public string Currency { get; set; }	// maxLength = 5
	}
}