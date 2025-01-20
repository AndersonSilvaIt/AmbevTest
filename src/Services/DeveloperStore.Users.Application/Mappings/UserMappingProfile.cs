using AutoMapper;
using DeveloperStore.Users.Application.Commands.CreateUser;
using DeveloperStore.Users.Application.DTOs;
using DeveloperStore.Users.Domain.Entities;
using DeveloperStore.Users.Domain.Enums;
using DeveloperStore.Users.Domain.ValueObjects;

namespace DeveloperStore.Users.Application.Mappings
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Name, NameDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Geolocation, GeolocationDto>();

            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Name(src.Name.FirstName, src.Name.LastName)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(
                    src.Address.City,
                    src.Address.Street,
                    src.Address.Number,
                    src.Address.ZipCode,
                    new Geolocation(src.Address.Geolocation.Lat, src.Address.Geolocation.Long)
                )))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<UserStatus>(src.Status, true)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<UserRole>(src.Role, true)));
        }
    }
}
