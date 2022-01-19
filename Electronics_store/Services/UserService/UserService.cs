using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.UserRepository;
using Electronics_store.Utilities;
using Electronics_store.Utilities.JWTUtils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Electronics_store.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public ElectronicsStoreContext _context;
        private IJWTUtils _ijwtUtils;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ElectronicsStoreContext context, IJWTUtils ijwtUtils,
            IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _context = context;
            _ijwtUtils = ijwtUtils;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public UserRespondDTO GetUserByUserId(Guid Id)
        {
            User user = _userRepository.FindById(Id);

            if (user == null)
                throw new Exception("User not found");

            UserRespondDTO userRespondDto = _mapper.Map<UserRespondDTO>(user);
            return userRespondDto;
        }

        public void CreateUser(UserRegisterDTO user)
        {
            // verific ca username ul si emailul sa fie unice(sa nu se regaseasca in baza de date)
            if (_userRepository.GetByEmail(user.Email) != null || _userRepository.GetByUsername(user.Username) != null)
                throw new Exception("Email or username already exists");

            var userToCreate = _mapper.Map<User>(user);
            userToCreate.Role = Role.User;
            userToCreate.PasswordHash = BCryptNet.HashPassword(user.PasswordHash);
            userToCreate.DateCreated = DateTime.Now;
            userToCreate.DateModified = DateTime.Now;

            //o alta varianta 

            // var userToCreate = new User 
            // {
            //     FirstName = user.FirstName,
            //     LastName = user.LastName,
            //     Email = user.Email,
            //     Username = user.Username,
            //     Role = Role.User,
            //     PasswordHash = BCryptNet.HashPassword(user.PasswordHash),
            //     DateCreated = DateTime.Now,
            //     DateModified = DateTime.Now
            // };

            _userRepository.Create(userToCreate);
            _userRepository.Save();
        }

        public void CreateAdmin(UserRegisterDTO user)
        {
            // verific ca username ul si emailul sa fie unice(sa nu se regaseasca in baza de date)
            if (_userRepository.GetByEmail(user.Email) != null || _userRepository.GetByUsername(user.Username) != null)
                throw new Exception("Email or username already exists");

            var userToCreate = _mapper.Map<User>(user);

            userToCreate.Role = Role.Admin;
            userToCreate.PasswordHash = BCryptNet.HashPassword(user.PasswordHash);
            userToCreate.DateCreated = DateTime.Now;
            userToCreate.DateModified = DateTime.Now;

            _userRepository.Create(userToCreate);
            _userRepository.Save();
        }

        public List<UserRespondDTO> GetAllUsers()
        {
            List<User> usersList = _userRepository.GetAllUsers();

            if (usersList.Count == 0)
                throw new Exception("There are no users");

            List<UserRespondDTO> userRespondDto = _mapper.Map<List<UserRespondDTO>>(usersList);
            return userRespondDto;
        }


        public List<UserRespondDTO> GetAllUsersByName(string name)
        {
            List<User> usersList = _userRepository.GetAllUsersByName(name);
            if (usersList.Count == 0)
                throw new Exception("There are no users with this name");
            List<UserRespondDTO> userRespondDto = _mapper.Map<List<UserRespondDTO>>(usersList);
            return userRespondDto;
        }

        public void DeleteUserById(Guid id)
        {
            User user = _userRepository.FindById(id);

            if (user == null)
                throw new Exception("User not found");

            _userRepository.Delete(user);
            _userRepository.Save();
        }

        public void UpdateUser(UserRegisterDTO newUser, Guid id)
        {
            User userToUpdate = _userRepository.FindById(id);

            if (userToUpdate == null)
                throw new Exception("User not found");

            userToUpdate = _mapper.Map<UserRegisterDTO, User>(newUser, userToUpdate);

            userToUpdate.DateModified = DateTime.Now;
            
            if(newUser.PasswordHash != null)
            userToUpdate.PasswordHash = BCryptNet.HashPassword(newUser.PasswordHash);

            try
            {
                _userRepository.Update(userToUpdate);
                _userRepository.Save();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            // User user = _userRepository.FindById(id);
            //
            // if (newUser.FirstName != null)
            //     user.FirstName = newUser.FirstName;
            //
            // if (newUser.LastName != null)
            //     user.LastName = newUser.LastName;
            //
            // if (newUser.Email != null)
            //     user.Email = newUser.Email;
            //
            // if (newUser.Username != null)
            //     user.Username = newUser.Username;
            //
            // if (newUser.PasswordHash != null)
            //     user.PasswordHash = newUser.PasswordHash;
            //
            // user.DateModified = DateTime.Now;
            //
            // _userRepository.Save();
        }

        public UserResponseTokenDTO
            Authentificate(UserLoginDTO model) //asta e o metoda care verifica parolele (hash-ul cu parola noastra)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(model.Username));

            if (user == null || !BCryptNet.Verify(model.PasswordHash, user.PasswordHash))
            {
                return null;
            }

            //generam jwt token
            var jwtToken = _ijwtUtils.GenerateJWTToken(user);
            return new UserResponseTokenDTO(user, jwtToken);
        }

        // public List<Order> GetAllOrdersForAUser()
        // {
        //     return _userRepository.GetAllOrdersForAUser();
        // }
    }
}