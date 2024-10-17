namespace Application.Services;

using Application.Services.Interfaces;
using AutoMapper;
using Domain.Model.Interfaces;
using Infrastructure.Crosscutting.Validations;
using DTO = Application.DTO;


public class UpdateAuctionsService : IUpdateAuctionsService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly IKafkaProducer _KafkaProducer;

    public UpdateAuctionsService(
        IMapper mapper,
        IRepository repository,
              IKafkaProducer kafkaProducer)
    {
        _mapper = mapper;
        _repository = repository;
        _KafkaProducer = kafkaProducer;
    }

    public async Task UpdateAsync(DTO.Auction dtoAuction)
    {
        var existentAuction = _repository.GetByIdAsync(dtoAuction.Id);

        if (existentAuction == null)
        {
            throw new CustomValidationException(CustomValidationMessages.NonExistentAuction);
        }

        var Auction = _mapper.Map<Domain.Model.Entities.Auction>(dtoAuction);

        var validationErrors = Auction.Validate();

        if (validationErrors.Count > 0)
        {
            throw new CustomValidationException(validationErrors);
        }

        await _repository.UpdateAsync(Auction);

        await _KafkaProducer.ProduceAsync("AuctionTopic", "Auction as json");
    }
}