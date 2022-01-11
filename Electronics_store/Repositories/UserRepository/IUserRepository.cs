using System;
using System.Collections.Generic;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAllUsers();
        List<User> GetAllUsersByName(string name);
        User GetByUsername(string name);
        User GetByEmail(string name);
        
        List<Order> GetAllOrdersForAUser();

    }
}