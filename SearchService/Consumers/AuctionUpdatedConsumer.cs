using AutoMapper;
using Contracts;
using MassTransit;

using SearchService.Models;
using SearchService.Services;

namespace SearchService.Consumers;

public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
{
    private readonly IMapper _mapper;
    private readonly SearchSvc _searchSvc;

    public AuctionUpdatedConsumer(IMapper mapper,SearchSvc searchSvc)
    {
        _mapper = mapper;
        _searchSvc = searchSvc;
    }
    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
       var item= _mapper.Map<Item>(context.Message);
       await _searchSvc.UpdateItem(context.Message.Id, item);
    }
}
