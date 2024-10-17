namespace Domain.Model.Interfaces;

using Domain.Model.Entities;

public interface IRepository
{
    Task<Guid> CreateAsync(Auction Auction);

    Task UpdateAsync(Auction Auction);

    Task<Auction> GetByIdAsync(Guid id);

    Task<List<Auction>> SearchAsync(Domain.Model.SearchContext searchContext);
}