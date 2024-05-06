class Result<TSuccess, TFailure> {
  
  final TSuccess? _success;
  final TFailure? _error;
  final bool _isSuccess;

  const Result.fromSuccess(this._success) : _error = null, _isSuccess = true;
  const Result.fromFailure(this._error) : _success = null, _isSuccess = false;

  TResult match<TResult>(TResult Function(TSuccess) onSuccess, TResult Function(TFailure) onError) {
    return _isSuccess 
      ? onSuccess(_success as TSuccess) 
      : onError(_error as TFailure);
  }
}