using System.Collections.Generic;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetAllOrders();
        
    }
}