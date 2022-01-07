using System.Collections.Generic;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.DeliveryAddressRepository
{
    public interface IDeliveryAddressRepository : IGenericRepository<DeliveryAddress>
    {
        List<DeliveryAddress> GetAllDeliveryAddresses();
    }
}