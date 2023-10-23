namespace Contracts.Shared;

public record CardDataDto(string CardNumber, string Cardholder, DateTime ExpirationDate, int CVV_CVC);
