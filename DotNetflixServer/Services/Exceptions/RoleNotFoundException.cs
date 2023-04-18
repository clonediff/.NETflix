namespace Services.Exceptions;

public class RoleNotFoundException : Exception
{
    public RoleNotFoundException() : base("Не удалось найти роль")
    {
        
    }
}