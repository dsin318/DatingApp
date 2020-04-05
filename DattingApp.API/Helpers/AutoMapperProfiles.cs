using System.Linq;
using AutoMapper;
using DattingApp.API.Dtos;
using DattingApp.API.Models;

namespace DattingApp.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
             .ForMember(dest => dest.Age, opt =>
            opt.MapFrom(src => src.DateOfBirth.calculateAge()));

            CreateMap<User,UserForDetailDto>()
             .ForMember(dest => dest.PhotoUrl, opt =>
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
 .ForMember(dest => dest.Age, opt =>
            opt.MapFrom(src => src.DateOfBirth.calculateAge()));
            CreateMap<Photo,PhotoForDetailDto>();
        }
    }
}