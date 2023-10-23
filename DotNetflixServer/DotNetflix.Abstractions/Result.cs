namespace DotNetflix.Abstractions;

public class Result<TSuccess, TFailure>
{
    private readonly TSuccess? _success;
    private readonly TFailure? _failure;
    
    public bool IsSuccess { get; }

    public Result(TSuccess success)
    {
        _success = success;
        IsSuccess = true;
    }

    public Result(TFailure failure)
    {
        _failure = failure;
        IsSuccess = false;
    }

    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
    {
        return IsSuccess
            ? success(_success!)
            : failure(_failure!);
    }

    public static implicit operator Result<TSuccess, TFailure>(TSuccess success)
    {
        return new Result<TSuccess, TFailure>(success);
    }

    public static implicit operator Result<TSuccess, TFailure>(TFailure failure)
    {
        return new Result<TSuccess, TFailure>(failure);
    }
}