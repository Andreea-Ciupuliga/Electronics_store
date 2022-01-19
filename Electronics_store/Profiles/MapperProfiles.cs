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
            CreateMap<CategoryRegisterDTO, Category>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
            CreateMap<Category, CategoryRespondDTO>();
            
            //Product
            CreateMap<ProductRegisterDTO, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
            CreateMap<ProductUpdateDTO, Product>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && src.Price!=0));;
            CreateMap<Product, ProductRespondDTO>();
            
            //Order
            CreateMap<OrderRegisterDTO,Order>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
            CreateMap<OrderUpdateDTO,Order>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
            
            //DeliveryAddress
            CreateMap<DeliveryAddressRegisterDTO,DeliveryAddress>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
            CreateMap<DeliveryAddressUpdateDTO,DeliveryAddress>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null ));;
            CreateMap<OrderRegisterDTO,DeliveryAddressRegisterDTO>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null ));;
            
            //OrderProductRelation
            CreateMap<OrderProductRelationRegisterDTO,OrderProductRelation>();
            CreateMap<OrderRegisterDTO,OrderProductRelationRegisterDTO>();
        }

        
    }
}