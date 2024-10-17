namespace Application.DTO;

using Application.DTO.Enum;

public class Auction
{
    public Guid Id { get; set; }

    public AuctionsStatus Status { get; set; }

    public Guid VehicleId { get; set; }

    public double StartBid { get; set; }
}