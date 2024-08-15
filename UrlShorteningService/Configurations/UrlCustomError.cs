namespace UrlShorteningService.Configurations;

public class UrlCustomError
{
    public UrlErrorType CustomError { get; set; }
}

public enum UrlErrorType
{
    InvalidUrl
}