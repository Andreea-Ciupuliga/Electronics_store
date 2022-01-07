using System;
using System.Collections.Generic;
using Electronics_store.DTOs;
using Electronics_store.Models;

namespace Electronics_store.Services.DeliveryAddressService
{
    public interface IDeliveryAddressService
    {
        public List<DeliveryAddress> GetAllDeliveryAddresses();

        DeliveryAddress GetDeliveryAddressByDeliveryAddressId(Guid Id);

        void CreateDeliveryAddress(DeliveryAddressRegisterDTO entity);

        void DeleteDeliveryAddressById(Guid id);

        void UpdateDeliveryAddress(DeliveryAddressUpdateDTO deliveryAddress, Guid id);
    }
}