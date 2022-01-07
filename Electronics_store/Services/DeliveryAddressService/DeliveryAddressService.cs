using System;
using System.Collections.Generic;
using AutoMapper;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.DeliveryAddressRepository;
using Microsoft.Data.SqlClient;

namespace Electronics_store.Services.DeliveryAddressService
{
    public class DeliveryAddressService : IDeliveryAddressService
    {
        public IDeliveryAddressRepository _deliveryAddressRepository;
        private readonly IMapper _mapper;

        public DeliveryAddressService(IDeliveryAddressRepository deliveryAddressRepository, IMapper mapper)
        {
            _deliveryAddressRepository = deliveryAddressRepository;
            _mapper = mapper;
        }

        public List<DeliveryAddress> GetAllDeliveryAddresses()
        {
            List<DeliveryAddress> deliveryAddressesList = _deliveryAddressRepository.GetAllDeliveryAddresses();

            if (deliveryAddressesList.Count == 0)
                throw new Exception("There are no Delivery Addresses");

            return deliveryAddressesList;
        }

        public DeliveryAddress GetDeliveryAddressByDeliveryAddressId(Guid Id)
        {
            DeliveryAddress deliveryAddress = _deliveryAddressRepository.FindById(Id);

            if (deliveryAddress == null)
                throw new Exception("Delivery Address not found");

            return deliveryAddress;
        }

        public void CreateDeliveryAddress(DeliveryAddressRegisterDTO entity)
        {
            var deliveryAddressToCreate = _mapper.Map<DeliveryAddress>(entity);
            deliveryAddressToCreate.DateCreated = DateTime.Now;
            deliveryAddressToCreate.DateModified = DateTime.Now;

            _deliveryAddressRepository.Create(deliveryAddressToCreate);
            _deliveryAddressRepository.Save();
        }

        public void DeleteDeliveryAddressById(Guid id)
        {
            DeliveryAddress deliveryAddress = _deliveryAddressRepository.FindById(id);
            
            if (deliveryAddress == null)
                throw new Exception("Delivery Address not found");
            
            _deliveryAddressRepository.Delete(deliveryAddress);
            _deliveryAddressRepository.Save();
        }

        public void UpdateDeliveryAddress(DeliveryAddressUpdateDTO deliveryAddress, Guid id)
        {
            DeliveryAddress deliveryAddressToUpdate = _deliveryAddressRepository.FindById(id);
            
            if (deliveryAddressToUpdate == null)
                throw new Exception("Delivery Address not found");

            deliveryAddressToUpdate =
                _mapper.Map<DeliveryAddressUpdateDTO, DeliveryAddress>(deliveryAddress, deliveryAddressToUpdate);
            deliveryAddressToUpdate.DateModified = DateTime.Now;

            try
            {
                _deliveryAddressRepository.Update(deliveryAddressToUpdate);
                _deliveryAddressRepository.Save();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}