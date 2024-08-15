using Service.Utilities;
using ServiceContracts.Models;

namespace ServiceContracts.Contracts;

public interface IUrlManagementService
{
    Task<GetShortenedUrlServiceModel> CreateShortenedUrlAsync(string originalUrl, CancellationToken cancellationToken);
}