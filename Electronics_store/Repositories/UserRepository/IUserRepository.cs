using System;
using System.Collections.Generic;
using System.Linq;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IQueryable<RespondUserDTO> GetAllUsers();
        IQueryable<RespondUserDTO> GetAllUsersByName(string name);

    }
}