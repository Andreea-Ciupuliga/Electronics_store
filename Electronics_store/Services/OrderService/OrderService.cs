using System;
using System.Collections.Generic;
using AutoMapper;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.OrderRepository;
using Microsoft.Data.SqlClient;

namespace Electronics_store.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        public ElectronicsStoreContext _context;
        public IOrderRepository _orderRepository;


        public OrderService(IMapper mapper, ElectronicsStoreContext context, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _context = context;
            _orderRepository = orderRepository;
        }


        public Order GetOrderByOrderId(Guid Id)
        {
            Order order = _orderRepository.FindById(Id);

            if (order == null)
                throw new Exception("Order not found");

            return order;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> ordersList = _orderRepository.GetAllOrders();

            if (ordersList.Count == 0)
                throw new Exception("There are no orders");
            
            return ordersList;
        }
        
        public List<Order> GetAllOrdersForAUser()
        {
            return _orderRepository.GetAllOrdersForAUser();
        }

        public void CreateOrder(OrderRegisterDTO entity)
        {
            var orderToCreate = _mapper.Map<Order>(entity);
            orderToCreate.DateCreated = DateTime.Now;
            orderToCreate.DateModified = DateTime.Now;

            _orderRepository.Create(orderToCreate);
            _orderRepository.Save();
        }

        public void DeleteOrderById(Guid id)
        {
            Order order = _orderRepository.FindById(id);
            
            if (order == null)
                throw new Exception("Order not found");
            
            _orderRepository.Delete(order);
            _orderRepository.Save();
        }

        public void UpdateOrder(OrderUpdateDTO order, Guid id)
        {
            Order orderToUpdate = _orderRepository.FindById(id);
            
            if (orderToUpdate == null)
                throw new Exception("Order not found");

            orderToUpdate = _mapper.Map<OrderUpdateDTO, Order>(order, orderToUpdate);
            orderToUpdate.DateModified = DateTime.Now;

            try
            {
                _orderRepository.Update(orderToUpdate);
                _orderRepository.Save();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}