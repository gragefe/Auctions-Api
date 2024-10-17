namespace Auctions.API.DependencyInjection;

using Application.Services.Interfaces;
using AuctionsServices = Application.Services;

public static class Auctionservices
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services
              .AddScoped<ICreateAuctionsService, AuctionsServices.CreateAuctionsService>();
        builder.Services
              .AddScoped<IUpdateAuctionsService, AuctionsServices.UpdateAuctionsService>();
        builder.Services
              .AddScoped<IGetByIdAuctionsService, AuctionsServices.GetByIdAuctionsService>();
        builder.Services
              .AddScoped<ISearchAuctionsService, AuctionsServices.SearchAuctionsService>();
    }
}