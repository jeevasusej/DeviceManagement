using AutoMapper;
using DeviceManagement.Api.Models;
using DeviceManagement.Entity;

namespace DeviceManagement.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Business object to Api
            CreateMap<User, UserModel>();
            CreateMap<User, RegisterModel>();

            // Api objects to Business Objects
            CreateMap<UserModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(um => um.Username))
                .ForMember(u => u.Name, opt => opt.MapFrom(um => um.Name))
                .ForMember(u => u.Email, opt => opt.MapFrom(um => um.Email))
                .ForMember(u => u.IsActive, opt => opt.MapFrom(um => um.IsActive));

            CreateMap<RegisterModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(rm => rm.Username))
                .ForMember(u => u.Name, opt => opt.MapFrom(rm => rm.Name))
                .ForMember(u => u.Email, opt => opt.MapFrom(rm => rm.Email));
        }
    }
}