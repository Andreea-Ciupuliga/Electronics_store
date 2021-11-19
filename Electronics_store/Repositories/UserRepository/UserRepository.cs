using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ElectronicsStoreContext _context;

        public UserRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public User GetById(Guid id)
        {
            return _table.FirstOrDefault(u => u.Id.Equals(id));
        }

    }
}