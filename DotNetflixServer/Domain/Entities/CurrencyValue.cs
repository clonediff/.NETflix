namespace Domain.Entities;

public class CurrencyValue
{
	public int Id { get; set; }
	public uint Value { get; set; }
	public string Currency { get; set; } = null!;	// maxLength = 5
}