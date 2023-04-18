namespace Services.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Не удалось найти пользователя")
    {
        
    }
}