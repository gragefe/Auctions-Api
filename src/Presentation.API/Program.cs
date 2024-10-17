using Application.Services;
using Infrastructure.Crosscutting.Validations;
using Presentation.API.DependencyInjection;
using Auctions.API.DependencyInjection;
using Auctions.API.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

Repositories.AddRepositories(builder);
Auctionservices.AddServices(builder);
Gateways.AddGateways(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();