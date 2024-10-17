namespace Application.Services;

using Application.Services.Interfaces;
using AutoMapper;
using Domain.Model.Interfaces;
using Infrastructure.Crosscutting.Validations;
using System.ComponentModel.DataAnnotations;
using DTO = Application.DTO;


public class CreateAuctionsService : ICreateAuctionsService
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly IKafkaProducer _KafkaProducer;
    private readonly IVehiclesGateway _vehiclesGateway;

    public CreateAuctionsService(
        IMapper mapper,
        IRepository repository,
        IKafkaProducer kafkaProducer,
        IVehiclesGateway vehiclesGateway)
    {
        _mapper = mapper;
        _repository = repository;
        _KafkaProducer = kafkaProducer;
        _vehiclesGateway = vehiclesGateway;
    }

    public async Task<Guid> CreateAsync(DTO.Auction dtoAuction)
    {
        var vehicle = await _vehiclesGateway.GetVehicle(dtoAuction.VehicleId);

        if (vehicle.AuctionId != null)
        {
            throw new CustomValidationException(CustomValidationMessages.VehicleAlreadyInUse);
        }

        var Auction = _mapper.Map<Domain.Model.Entities.Auction>(dtoAuction);

        var validationErrors = Auction.Validate();

        if (validationErrors.Count > 0)
        {
            throw new CustomValidationException(validationErrors);
        }

        await _repository.CreateAsync(Auction);

        await _KafkaProducer.ProduceAsync("AuctionTopic", "Auction as json");

        return Auction.Id;
    }
}