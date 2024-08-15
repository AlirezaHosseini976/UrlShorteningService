using System.Reflection;
using DataContracts.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using ServiceContracts.Models;

namespace Service.Configurations;

public static class BusinessLayerMappingConfig
{
    public static void DataLayerMapping(this IServiceCollection service)
    {
        TypeAdapterConfig< ShortUrlDataModel,GetShortenedUrlServiceModel >.NewConfig()
            .Map(d => d.OriginalUrl, src => src.OriginalUrl)
            .Map(d => d.ShortCode, src => src.ShortCode)
            .Map(d=>d.CreatedAt, src=>src.CreatedAt);
        
        
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        service.AddSingleton(TypeAdapterConfig.GlobalSettings);
    }
}