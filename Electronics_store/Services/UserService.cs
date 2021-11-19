using System;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.UserRepository;

namespace Electronics_store.Services
{
    public class UserService : IUserService
    {

        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO GetDataByUserId(Guid Id)
        {
            User user = _userRepository.GetById(Id);
            UserDTO userDto = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            
            return userDto;
        }

        public void CreateUser(UserDTO user)
        {
            var userToCreate = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email =user.Email
            };
            
            _userRepository.Create(userToCreate);
            _userRepository.Save();
        }
    }
}