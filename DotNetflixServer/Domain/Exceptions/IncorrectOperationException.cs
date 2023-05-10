namespace Domain.Exceptions;

public class IncorrectOperationException : Exception
{
    public IncorrectOperationException(string message) : base(message) { }
}