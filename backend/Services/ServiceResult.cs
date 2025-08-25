using System.Diagnostics.Tracing;

namespace WorkSense.Backend.Services.Results;

public enum ResultError
{
    NotFound,
    BadRequest,
    None
}

public class ServiceResult<T>
{
    public ServiceResult(bool isError, T? value, ResultError? error, string? message)
    {
        Value = value;
        Message = message ?? string.Empty;
        Error = error ?? ResultError.None;
    }

    public bool IsError { get; }
    public T? Value { get; }
    public string Message { get; }
    public ResultError Error { get; }

    public static ServiceResult<T> Success(T value)
    {
        return new ServiceResult<T>(false, value, null, null);
    }

    public static ServiceResult<T> Failure(ResultError error, string message)
    {
        return new ServiceResult<T>(true, default(T), error, message);
    }
}