namespace DotNetflix.Abstractions;

public class Result<TSuccess, TFailure>
{
    private readonly TSuccess? _success;
    private readonly TFailure? _failure;
    private readonly bool _isSuccess;

    public Result(TSuccess success)
    {
        _success = success;
        _isSuccess = true;
    }

    public Result(TFailure failure)
    {
        _failure = failure;
        _isSuccess = false;
    }

    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
    {
        return _isSuccess
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