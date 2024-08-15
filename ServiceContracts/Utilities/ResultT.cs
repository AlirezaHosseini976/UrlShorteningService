namespace Service.Utilities;

public class Result<T> : Result
{
    public  T Value { get; }

    protected internal Result(T value, bool isSuccess, string error)
        : base(isSuccess, error)
    {
        Value = value;
    }
}