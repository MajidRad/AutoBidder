using AuctionService.DTOs;
using AuctionService.Entities;
using Mapster;

namespace AuctionService.RequestHelper;

public static class MapsterConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.NewConfig<Auction, AuctionDto>();

    
        services.AddSingleton(config);
    }
}