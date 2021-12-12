using System;
using System.Collections.Generic;
using Electronics_store.DTOs;

namespace Electronics_store.Services.UserService
{
    public interface IUserService
    {
        UserRespondDTO GetUserByUserId(Guid Id);
        public List<UserRespondDTO> GetAllUsers();
        public List<UserRespondDTO> GetAllUsersByName(string name);

        void CreateUser(UserRegisterDTO entity);
        void CreateAdmin(UserRegisterDTO entity);

        void DeleteUserById(Guid id);
        void UpdateUser(UserRegisterDTO user, Guid id);

        UserResponseTokenDTO Authentificate(UserLoginDTO model);
    }
}