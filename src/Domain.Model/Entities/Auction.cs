namespace Domain.Model.Entities;

using Domain.Model.Enum;
using Domain.Model.Validators;

public class Auction
{
    public Guid Id { get; set; }

    public AuctionsStatus Status { get; set; }

    public Guid VehicleId { get; set; }

    public double StartBid { get; set; }

    public virtual List<string> Validate()
    {
        var errors = new List<string>();

        if (this.VehicleId == default)
        {
            errors.Add($"{nameof(this.VehicleId)} {CustomValidationMessages.IsRequired}");
        }

        if (this.Status == AuctionsStatus.None)
        {
            errors.Add($"{nameof(this.Status)} {CustomValidationMessages.IsRequired}");
        }

        return errors;
    }
}