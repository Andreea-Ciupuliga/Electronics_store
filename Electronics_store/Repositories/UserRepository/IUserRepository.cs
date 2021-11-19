using System;
using System.Collections.Generic;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetById(Guid id);

    }
}