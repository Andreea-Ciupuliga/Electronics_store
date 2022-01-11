using System;
using AutoMapper;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.OrderProductRelationRepository;
using Microsoft.Data.SqlClient;

namespace Electronics_store.Services.OrderProductRelationService
{
    public class OrderProductRelationService : IOrderProductRelationService
    {
        public IOrderProductRelationRepository _orderProductRelationRepository;
        public ElectronicsStoreContext _context;
        private readonly IMapper _mapper;

        public OrderProductRelationService(IOrderProductRelationRepository orderProductRelationRepository, ElectronicsStoreContext context, IMapper mapper)
        {
            _orderProductRelationRepository = orderProductRelationRepository;
            _context = context;
            _mapper = mapper;
        }
        
        public void CreateOrderProductRelation(OrderProductRelationRegisterDTO orderProductRelation)
        {
            var orderProductRelationToCreate = _mapper.Map<OrderProductRelation>(orderProductRelation);
            orderProductRelationToCreate.DateCreated = DateTime.Now;
            orderProductRelationToCreate.DateModified = DateTime.Now; 
            
            _orderProductRelationRepository.Create(orderProductRelationToCreate);
            _orderProductRelationRepository.Save();
        }
        
        public void UpdateOrderProductRelation(OrderProductRelationRegisterDTO newOrderProductRelation, Guid id)
        {
            OrderProductRelation orderProductRelationToUpdate =  _orderProductRelationRepository.FindById(id);
            orderProductRelationToUpdate =_mapper.Map<OrderProductRelationRegisterDTO,OrderProductRelation>(newOrderProductRelation,orderProductRelationToUpdate);
            orderProductRelationToUpdate.DateModified =DateTime.Now;

            try
            {
                _orderProductRelationRepository.Update(orderProductRelationToUpdate);
                _orderProductRelationRepository.Save();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
           
        }
    }
}