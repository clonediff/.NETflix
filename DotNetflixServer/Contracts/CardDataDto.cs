namespace Contracts;

public record CardDataDto(string CardNumber, string Cardholder, DateTime ExpirationDate, int CVV_CVC);