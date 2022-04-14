using AutoMapper;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, DTO.Request.SendUserDTO>()
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive))
                .ForMember<string>(x => x.Password, x => x.MapFrom<string>(x => x.Authentication.Password))
                .ReverseMap();

            CreateMap<User, UserResponseDTO>()
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive))
                .ReverseMap();

            CreateMap<User, DTO.Request.SendUserDTO>()
                .ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive))
                .ForMember<string>(x => x.Password, x => x.MapFrom<string>(x => x.Authentication.Password))
                .ReverseMap();

            CreateMap<UserResponseDTO, LoginDTO>()
                .ForMember(x => x.Email, x => x.MapFrom(x => x.Email))
                .ReverseMap();
        }
    }
}
