namespace Application.Services.Interfaces;

using Application.DTO;

public interface IGetByIdAuctionsService
{
    public Task<Auction> GetByIdAsync(Guid Id);
}