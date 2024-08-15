using System.Reflection;
using DataAccess.Entities;
using DataContracts.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Configurations;

public static class DataLayerMappingConfig
{
    public static void DataLayerMapping(this IServiceCollection service)
    {
        TypeAdapterConfig<ShortUrlDataModel, ShortUrl>.NewConfig()
            .Map(d => d.OriginalUrl, src => src.OriginalUrl)
            .Map(d => d.ShortCode, src => src.ShortCode)
            .Map(d=>d.CreatedAt, src=>src.CreatedAt);

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        service.AddSingleton(TypeAdapterConfig.GlobalSettings);
    }
}