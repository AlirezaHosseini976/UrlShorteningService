using DataContracts.Models;

namespace DataContracts.Contracts;

public interface IUrlManagementRepository
{
    Task CreateShortenedUrlAsync(ShortUrlDataModel shortUrlDataModel, CancellationToken cancellationToken);
    Task<bool> IsShortenedUrlExistAsync(string shortCode,CancellationToken cancellationToken);
}