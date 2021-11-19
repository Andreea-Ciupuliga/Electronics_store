using System;
using Electronics_store.DTOs;
using Electronics_store.Models;

namespace Electronics_store.Services
{
    public interface IUserService
    {
        UserDTO GetDataByUserId(Guid Id);
        
        void CreateUser(UserDTO entity);
    }
}