namespace Application.Services.Interfaces;

using Application.DTO;
using System.Collections.Generic;

public interface ISearchAuctionsService
{
    Task<List<Auction>> SearchAsync(SearchContext searchContextDto);
}