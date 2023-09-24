namespace Contracts.AuthDto;

public class AuthResultDto
{
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }
    public AuthResultDto(string errorMessage)
    {
        IsSuccess = false;
        ErrorMessage = errorMessage;
    }

    public AuthResultDto()
    {
        IsSuccess = true;
        ErrorMessage = "";
    }
}