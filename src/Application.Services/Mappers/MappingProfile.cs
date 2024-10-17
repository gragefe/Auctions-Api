namespace Application.Services;

using AutoMapper;
using DTO = Application.DTO;
using Domain = Domain.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DTO.Auction, Domain.Entities.Auction>();
        CreateMap<Domain.Entities.Auction, DTO.Auction>();

        CreateMap<DTO.SearchContext, Domain.SearchContext>();
    }
}