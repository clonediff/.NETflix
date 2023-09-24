namespace Domain.Entities;

public class Fees
{
	public int Id { get; set; }
	public int? WorldId { get; set; }
	public CurrencyValue? World { get; set; }
	public int? RussiaId { get; set; }
	public CurrencyValue? Russia { get; set; }
	public int? USAId { get; set; } 
	public CurrencyValue? USA { get; set; } 
}