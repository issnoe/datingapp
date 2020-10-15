using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<Photo, PhotoDto>();

            CreateMap<AppUser, MemberDto>()
            // Mapper to get set the foto 
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                    src.Photos.FirstOrDefault(x => x.IsMain).Url))
             // Mapper to get set the age 
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()))
            // Mapper to get set the age 
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.TransformGenre()));
            CreateMap<Photo, PhotoDto>();
        }
    }
}