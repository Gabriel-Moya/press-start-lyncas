using AutoMapper;
using PressStartApi.DTO;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, InsertUserDTO>()
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive))
                .ForMember(x => x.Password, x => x.MapFrom(x => x.Authentication.Password))
                .ReverseMap();

            CreateMap<User, UserResponseDTO>()
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive))
                .ReverseMap();

            CreateMap<User, UpdateUserDTO>()
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive))
                .ForMember(x => x.Password, x => x.MapFrom(x => x.Authentication.Password))
                .ReverseMap();

            CreateMap<UserResponseDTO, LoginDTO>()
                .ForMember(x => x.Email, x => x.MapFrom(x => x.Email))
                .ReverseMap();
        }
    }
}
