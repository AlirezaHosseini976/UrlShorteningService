using DataAccess.Entities;
using DataContracts.Contracts;
using DataContracts.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class UrlManagementRepository : IUrlManagementRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UrlManagementRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task CreateShortenedUrlAsync(ShortUrlDataModel shortUrlDataModel, CancellationToken cancellationToken)
    {
        var shortenedUrl = shortUrlDataModel.Adapt<ShortUrl>();
        _applicationDbContext.ShortUrls.Add(shortenedUrl);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsShortenedUrlExistAsync(string shortCode, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.ShortUrls.AnyAsync(u => u.ShortCode == shortCode, cancellationToken);
    }
}