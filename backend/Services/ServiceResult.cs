namespace WorkSense.Backend.Services.Results;

public enum ResultError
{
    NotFound,
    BadRequest,
    NullReturnValue,
    None
}

public interface IServiceResult
{
    public bool IsError { get; }
    public ResultError Error { get; }

}

public class ServiceResult<T> : IServiceResult
{
    public ServiceResult(bool isError, T? value, ResultError error, string message)
    {
        IsError = isError;
        Value = value;
        Message = message;
        Error = error;
    }

    public bool IsError { get; }
    public T? Value { get; }
    public string Message { get; }
    public ResultError Error { get; }

    public static ServiceResult<T> Success(T value)
    {
        if (value is null)
            return Failure(ResultError.NullReturnValue, "Result contains null value");

        return new ServiceResult<T>(false, value, ResultError.None, string.Empty);
    }

    public static ServiceResult<T> Failure(ResultError error, string message)
    {
        return new ServiceResult<T>(true, default(T), error, message);
    }
}

public class ServiceResult : IServiceResult
{
    public ServiceResult(bool isError, ResultError error, string message)
    {
        IsError = isError;
        Message = message;
        Error = error;

    }

    public bool IsError { get; }
    public string Message { get; }
    public ResultError Error { get; }

    public static ServiceResult Success()
    {
        return new ServiceResult(false, ResultError.None, string.Empty);
    }

    public static ServiceResult Failure(ResultError error, string message)
    {
        return new ServiceResult(true, error, message);
    }
}