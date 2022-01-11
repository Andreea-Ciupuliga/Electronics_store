using System.Collections.Generic;
using System.Linq;
using Electronics_store.Data;
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

        public List<User> GetAllUsers()
        {
            return new List<User>(_context.Users.AsNoTracking().ToList());

            //o varianta:

            //var usersAsDto = new List<UserRespondDTO>();

            // foreach (var user in users)
            // {
            //     var userAsDto = _mapper.Map<User, UserRespondDTO>(user);
            //     usersAsDto.Add(userAsDto);
            // }

            //alta varianta: 

            // return _table.Select(x => new UserRespondDTO
            //  {
            //      FirstName = x.FirstName,
            //      LastName = x.LastName,
            //      Email = x.Email,
            //      Username = x.Username,
            //  });
        }

        public List<User> GetAllUsersByName(string name)
        {
            return new List<User>(_context.Users.Where(u => u.FirstName.Equals(name) || u.LastName.Equals(name)));

            //alta varianta:

            // return _table.Where(x => x.FirstName.Equals(name) || x.LastName.Equals(name))
            //             .Select(x => new UserRespondDTO
            //             {
            //                 FirstName = x.FirstName,
            //                 LastName = x.LastName,
            //                 Email = x.Email,
            //                 Username = x.Username,
            //             });
        }

        public User GetByUsername(string name)
        {
            return _context.Users.FirstOrDefault(u=>u.Username.Equals(name));
        }

        public User GetByEmail(string name)
        {
            return _context.Users.FirstOrDefault(u=>u.Email.Equals(name));
        }
        
        public List<Order> GetAllOrdersForAUser()
        {
            var result = _table.Join(_context.Orders, user => user.Id, order => order.UserId,
                (user, order) => new {user, order}).Select(obj => obj.order).Where(obj=>obj.User.Email.Equals("User1@email.com"));
        
            return result.ToList();
        }
        
    }
}