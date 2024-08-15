namespace DataContracts.Models;

public class ShortUrlDataModel
{
    public string OriginalUrl { get; set; }
    public string ShortCode { get; set; }
    public DateTime CreatedAt { get; set; }
    
}