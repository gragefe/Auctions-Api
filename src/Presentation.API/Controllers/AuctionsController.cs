namespace Auctions.API.Controllers;

using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("[controller]")]
public class AuctionsController : Controller
{
    private readonly ICreateAuctionsService _createAuctionsService;
    private readonly IUpdateAuctionsService _updateAuctionsService;
    private readonly ISearchAuctionsService _searchAuctionsService;
    private readonly IGetByIdAuctionsService _getByIdAuctionsService;

    public AuctionsController(
        ICreateAuctionsService createAuctionsService,
        IUpdateAuctionsService updateAuctionsService,
        ISearchAuctionsService searchAuctionsService,
        IGetByIdAuctionsService getByIdAuctionsService)
    {
        _createAuctionsService = createAuctionsService;
        _updateAuctionsService = updateAuctionsService;
        _searchAuctionsService = searchAuctionsService;
        _getByIdAuctionsService = getByIdAuctionsService;
    }

    [HttpPost(Name = "Create")]
    public async Task<ActionResult> CreateAuctionsAsync([FromBody] Auction Auction)
    {
        await _createAuctionsService.CreateAsync(Auction);
        var AuctionId = Guid.NewGuid();
        var resourceLocationUri = this.Request?.GetDisplayUrl() + $"/{AuctionId}";
        return this.Created(resourceLocationUri, null);
    }

    [HttpPut(Name = "Update")]
    public async Task<ActionResult> UpdateAuctionsAsync([FromBody] Auction Auction)
    {
        await _updateAuctionsService.UpdateAsync(Auction);
        var AuctionId = Guid.NewGuid();
        var resourceLocationUri = this.Request?.GetDisplayUrl() + $"/{AuctionId}";
        return this.Created(resourceLocationUri, null);
    }

    [HttpGet, Route("GetById")]
    public async Task<ActionResult> GetAuctionsByIdAsync([Required, FromQuery] Guid id)
    {
        var Auction = await _getByIdAuctionsService.GetByIdAsync(id);
        return this.Ok( Auction);
    }

    [HttpPost, Route("Search")]
    public async Task<ActionResult<Page<Auction>>> SearechAuctionsAsync(
        [FromBody] SearchContext searchContext,
        [FromQuery] int? page = null,
        [FromQuery] int? pageSize = null
        )
    {
        await _searchAuctionsService.SearchAsync(searchContext);
        var resourceLocationUri = this.Request?.GetDisplayUrl() + $"/{123}";
        return this.Created(resourceLocationUri, null);
    }
}