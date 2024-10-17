namespace Application.Services.Interfaces;

using Application.DTO;

public interface ICreateAuctionsService
{
    public Task<Guid> CreateAsync(Auction DtoAuction);
}