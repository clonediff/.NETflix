namespace DotNetflixMobileAPI.GraphQL;

public class ExceptionToErrorHandler : IErrorFilter
{
    public IError OnError(IError error)
    {
        return error.Exception is not null ? error.WithMessage(error.Exception.Message) : error;
    }
}
