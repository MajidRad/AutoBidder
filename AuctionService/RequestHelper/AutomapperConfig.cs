using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelper;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {

        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(d => d.Item, o => o.MapFrom(s => s));
        CreateMap<CreateAuctionDto, Item>();
        CreateMap<AuctionDto, AuctionCreated>();

        CreateMap<Auction, AuctionUpdated>().IncludeMembers(a => a.Item);
        CreateMap<Item, AuctionUpdated>();

        CreateMap<Auction, AuctionDeleted>().IncludeMembers(a => a.Item);
        CreateMap<Item, AuctionDeleted>().ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id.ToString()));
    }
}
