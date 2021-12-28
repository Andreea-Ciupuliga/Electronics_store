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
            //CreateMap<User, UserRegisterDTO>(); //asta inca nu stiu daca imi trebuie sau nu
            CreateMap<UserRegisterDTO, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserLoginDTO>();
            CreateMap<User, UserResponseTokenDTO>();
            
            //Category
            CreateMap<CategoryRegisterDTO, Category>();
            CreateMap<Category, CategoryRespondDTO>();
            
            //Product
            CreateMap<ProductRegisterDTO, Product>();
            CreateMap<Product, ProductRespondDTO>();
            
            //Order
            CreateMap<Order, OrderRegisterDTO>();
        }

        
    }
}