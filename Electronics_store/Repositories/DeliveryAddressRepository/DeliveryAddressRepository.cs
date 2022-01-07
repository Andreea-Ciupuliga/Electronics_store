using System.Collections.Generic;
using System.Linq;
using Electronics_store.Data;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Repositories.DeliveryAddressRepository
{
    public class DeliveryAddressRepository : GenericRepository<DeliveryAddress>, IDeliveryAddressRepository
    {
        private readonly ElectronicsStoreContext _context;

        public DeliveryAddressRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public List<DeliveryAddress> GetAllDeliveryAddresses()
        {
            return new List<DeliveryAddress>(_context.DeliveryAddresses.AsNoTracking().ToList());
        }
    }
}