using Electronics_store.DTOs;
using Electronics_store.Models;
using AutoMapper;

namespace Electronics_store.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //User
            CreateMap<User, UserRespondDTO>();
            CreateMap<User, UserRegisterDTO>();
            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<User, UserResponseTokenDTO>();
            
            //Category
            CreateMap<Category, CategoryRegisterDTO>();
            
            //Product
            CreateMap<Product, ProductRegisterDTO>();
        }

        
    }
}