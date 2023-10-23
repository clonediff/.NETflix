namespace DotNetflix.Abstractions;

public class Result<TSuccess, TFailure>
{
    private readonly TSuccess? _success;
    private readonly TFailure? _failure;
    private readonly bool _sSuccess;

    public Result(TSuccess success)
    {
        _success = success;
        _sSuccess = true;
    }

    public Result(TFailure failure)
    {
        _failure = failure;
        _sSuccess = false;
    }

    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TFailure, TResult> failure)
    {
        return _sSuccess
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