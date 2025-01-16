using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.DTO;
using looply.Models;
using AutoMapper;

namespace looply.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Number_Of_Followers, opt => opt.MapFrom(src => src.Followers.Count))
                .ForMember(dest => dest.Number_Of_Following, opt => opt.MapFrom(src => src.Following.Count));
            
            CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Number_Of_Comments, opt => opt.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.Number_Of_Likes, opt => opt.MapFrom(src => src.Likes.Count));
        }
    }
}