using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly SearchSvc _searchSvc;

    public SearchController(SearchSvc searchSvc)
    {
        _searchSvc = searchSvc;
    }


    [HttpGet]
    public async Task<ActionResult<List<Item>>> SearchItems(string? searchTerm = null)
    {
        var result = await _searchSvc.SearchItemsAsync(searchTerm);
        return result;
    }
}
