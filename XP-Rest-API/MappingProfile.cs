using AutoMapper;
using XP_Rest_API.Models;
using XP_Rest_API.Models.DTO;

namespace XP_Rest_API;
public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<CreateClientDTO, Client>()
      .ForMember(dest => dest.Id, opt => opt.Ignore())
      .ForMember(dest => dest.Emails, opt => opt.Ignore())
      .ForMember(dest => dest.Addresses, opt => opt.Ignore());

    CreateMap<Client, ClientDetailsDTO>()
      .ForMember(dest => dest.PrimaryEmail, opt =>
        opt.MapFrom(src => src.Emails
        .Where(e => e.IsPrimary)
        .Select(e => e.EmailAddress)
        .FirstOrDefault())
      )
      .ForMember(dest => dest.PrimaryAddress, opt =>
        opt.MapFrom(src => src.Addresses
        .Where(e => e.IsPrimary)
        .Select(e => e.GetFullAddress())
        .FirstOrDefault())
      );
  }
}

