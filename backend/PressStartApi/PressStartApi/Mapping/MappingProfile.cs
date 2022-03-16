using AutoMapper;
using PressStartApi.DTO;
using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, InsertUserDTO>().ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive)).ReverseMap();
            CreateMap<User, UserResponseDTO>().ForMember(x => x.IsActive, x => x.MapFrom(x => x.Authentication.IsActive)).ReverseMap();
        }
    }
}
