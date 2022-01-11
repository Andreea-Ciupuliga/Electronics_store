using Electronics_store.Data;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.OrderProductRelationRepository
{
    public class OrderProductRelationRepository : GenericRepository<OrderProductRelation>, IOrderProductRelationRepository
    {
        private readonly ElectronicsStoreContext _context;

        public OrderProductRelationRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}