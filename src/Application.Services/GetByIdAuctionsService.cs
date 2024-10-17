namespace Application.Services;

using Application.Services.Interfaces;
using AutoMapper;
using Domain.Model.Interfaces;
using Infrastructure.Crosscutting.Validations;
using DTO = Application.DTO;


public class GetByIdAuctionsService : IGetByIdAuctionsService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetByIdAuctionsService(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<DTO.Auction> GetByIdAsync(Guid id)
    {
        var Auction = await _repository.GetByIdAsync(id);

        if (Auction == null)
        {
            throw new CustomValidationException(CustomValidationMessages.NonExistentAuction);
        }

        var AuctionDto = _mapper.Map<DTO.Auction>(Auction);

        return AuctionDto;
    }
}