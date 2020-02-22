using AutoMapper;
using DeviceManagement.BL.Dto;
using DeviceManagement.BL.Modal;
using DeviceManagement.DL.Modal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.BL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterModal, User>()
                .ForMember(dest=> dest.Username, opt => opt.MapFrom(src=> src.Username))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<User, UserDto>()
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.LastLoginOn, opt => opt.MapFrom(src => src.LastLoginOn));
            
        }
    }
}
