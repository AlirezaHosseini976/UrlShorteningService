namespace Service.Utilities;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; }
    public bool IsFailure => !IsSuccess;
    
    protected Result(bool isSuccess, string error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Fail(string error) => new Result(false, error);
    public static Result<T> Fail<T>(string error) => new Result<T>(default(T), false, error);
    public static Result Ok() => new Result(true, string.Empty);
    public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);
}