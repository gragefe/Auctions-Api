namespace Application.Services.Interfaces;

using Application.DTO;

public interface IUpdateAuctionsService
{
    public Task UpdateAsync(Auction DtoAuction);
}