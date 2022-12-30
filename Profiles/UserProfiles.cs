using AutoMapper;
using WellaApi.Models;
using WellaApi.ViewModels;

namespace WellaApi.Profiles{
    public class UserProfiles : Profile{
        public UserProfiles()
        {
            //Default mapping when property namesare same
            //Mapping source to destination
            CreateMap<UserData, UserViewModel>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.FName,opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UName,opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.PNumber, opt => opt.MapFrom(src => src.Phonenumber))
            .ForMember(dest => dest.EAddress,opt => opt.MapFrom(src => src.EmailAddress))
            .ForMember(dest => dest.PRole, opt => opt.MapFrom(src => src.Role));
            // .ForMember(dest => dest.PUserGrade, opt => opt.MapFrom(src => src.UserGrade));
            
        }
    }
    
}