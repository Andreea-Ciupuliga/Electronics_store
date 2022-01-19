using System;
using System.Collections.Generic;
using System.Linq;
using Electronics_store.Data;
using Electronics_store.Models;
using Microsoft.EntityFrameworkCore;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.OrderRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ElectronicsStoreContext _context;

        public OrderRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>(_context.Orders.AsNoTracking().ToList());
        }
        
        public List<Order> GetAllOrdersForAUser(Guid userId)
        {
            var result = _table.Join(_context.Users, order => order.UserId ,user => user.Id ,
                (order,user) => new {order,user}).Select(obj => obj.order).Where(obj=>obj.User.Id.Equals(userId));
        
            return result.ToList();
        }
    }
}