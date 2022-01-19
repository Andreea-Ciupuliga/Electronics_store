using System;
using System.Collections.Generic;
using AutoMapper;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.OrderRepository;
using Electronics_store.Services.DeliveryAddressService;
using Electronics_store.Services.OrderProductRelationService;
using Microsoft.Data.SqlClient;

namespace Electronics_store.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        public ElectronicsStoreContext _context;
        public IOrderRepository _orderRepository;
        public IOrderProductRelationService _orderProductRelationService;
        public IDeliveryAddressService _deliveryAddressService;


        public OrderService(IDeliveryAddressService deliveryAddressService, IMapper mapper,
            ElectronicsStoreContext context, IOrderRepository orderRepository,
            IOrderProductRelationService orderProductRelationService)
        {
            _mapper = mapper;
            _context = context;
            _orderRepository = orderRepository;
            _orderProductRelationService = orderProductRelationService;
            _deliveryAddressService = deliveryAddressService;
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

        public List<Order> GetAllOrdersForAUser(Guid userId)
        {
            return _orderRepository.GetAllOrdersForAUser(userId);
        }

        public void CreateOrder(OrderRegisterDTO entity)
        {
            var orderToCreate = _mapper.Map<Order>(entity);
            orderToCreate.DateCreated = DateTime.Now;
            orderToCreate.DateModified = DateTime.Now;

            _orderRepository.Create(orderToCreate);


            //   var orderProductRelation = _mapper.Map<OrderProductRelationRegisterDTO>(entity);
            var orderProductRelation =
                new
                    OrderProductRelationRegisterDTO //o sa adaug si in tabela de orderProductRelation tot acum ptc dupa nu o sa mai stiu ce combinatie de orderId si productId aveam
                    {
                        OrderId = orderToCreate.Id,
                        ProductId = entity.ProductId
                    };

            var deliveryAddress = _mapper.Map<DeliveryAddressRegisterDTO>(entity);
            deliveryAddress.OrderId = orderToCreate.Id;

            // var deliveryAddress = new DeliveryAddressRegisterDTO //o sa adaug si in tabela de delivery address tot acum ptc dupa nu o sa mai stiu ce orderId am folosit
            // {
            //     City=entity.City,
            //     Street = entity.Street,
            //     Number = entity.Number,
            //     ZIPCode = entity.ZIPCode,
            //         
            //     OrderId = orderToCreate.Id,
            // };


            _orderProductRelationService.CreateOrderProductRelation(orderProductRelation);
            _deliveryAddressService.CreateDeliveryAddress(deliveryAddress);
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