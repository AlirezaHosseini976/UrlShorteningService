using DataContracts.Contracts;
using DataContracts.Models;
using Mapster;
using Service.Configurations;
using Service.Utilities;
using ServiceContracts.Contracts;
using ServiceContracts.Models;
using ServiceContracts.Utilities;

namespace Service.Services;

public class UrlManagementService : IUrlManagementService
{
    private readonly IUrlManagementRepository _urlManagementRepository;

    public UrlManagementService(IUrlManagementRepository urlManagementRepository)
    {
        _urlManagementRepository = urlManagementRepository;
    }

    public async Task<GetShortenedUrlServiceModel> CreateShortenedUrlAsync(string originalUrl, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(originalUrl) || !UrlValidator.IsValidUrl(originalUrl))
        {
            throw new Exception("The provided URL is invalid.");
        }
        string shortUrlToken;
        do
        {
            shortUrlToken = TokenGenerator.GenerateUniqueShortUrl();
        } while (await _urlManagementRepository.IsShortenedUrlExistAsync(shortUrlToken, cancellationToken));
        
        var shortenedUrl = new ShortUrlDataModel()
        {
            OriginalUrl = originalUrl,
            ShortCode = shortUrlToken,
            CreatedAt = DateTime.UtcNow,
            

        };
        await _urlManagementRepository.CreateShortenedUrlAsync(shortenedUrl, cancellationToken);
        var newlyCreatedUrl = shortenedUrl.Adapt<GetShortenedUrlServiceModel>();
        return newlyCreatedUrl;
    }
}