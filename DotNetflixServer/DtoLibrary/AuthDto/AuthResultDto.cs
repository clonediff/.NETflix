namespace DtoLibrary.AuthDto;

public class AuthResultDto
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    
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