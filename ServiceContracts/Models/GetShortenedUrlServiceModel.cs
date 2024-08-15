namespace ServiceContracts.Models;

public class GetShortenedUrlServiceModel
{
    public string OriginalUrl { get; set; }
    public string ShortCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}