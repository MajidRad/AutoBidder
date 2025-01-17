using Contracts;
using MassTransit;
using SearchService.Services;

namespace SearchService.Consumers;

public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
{
    private readonly SearchSvc _searchSvc;

    public AuctionDeletedConsumer(SearchSvc searchSvc)
    {
        _searchSvc = searchSvc;
    }
    public async Task Consume(ConsumeContext<AuctionDeleted> context)
    {
        await _searchSvc.RemoveItem(context.Message.Id);
    }
}
