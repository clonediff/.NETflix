namespace Contracts.AuthDto;

public class AuthResultDto
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; } = null!;

    public AuthResultDto(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }

    public AuthResultDto()
    {
        IsSuccess = true;
    }
}