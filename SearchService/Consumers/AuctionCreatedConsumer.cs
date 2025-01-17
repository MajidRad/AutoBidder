using AutoMapper;
using Contracts;
using Contracts.ExtensionMethods;
using MassTransit;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Consumers;

public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;
    private readonly SearchSvc _searchSvc;

    public AuctionCreatedConsumer(IMapper mapper,SearchSvc searchSvc)
    {
        _mapper = mapper;
        _searchSvc = searchSvc;
    }
    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        ConsoleEx.InfoMessage("Consuming Auction Created"+context.Message.Id);
        var item = _mapper.Map<Item>(context.Message);
        if (item.Model == "Foo") throw new  ArgumentException("cannot sell cars with name of Foo");
       await _searchSvc.InsertItem(item);
    }
}
