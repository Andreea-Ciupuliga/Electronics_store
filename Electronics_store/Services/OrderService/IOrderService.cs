using System;
using System.Collections.Generic;
using Electronics_store.DTOs;
using Electronics_store.Models;

namespace Electronics_store.Services.OrderService
{
    public interface IOrderService
    {
        Order GetOrderByOrderId(Guid Id);
        public List<Order> GetAllOrders();
        void CreateOrder(OrderRegisterDTO entity);
        void DeleteOrderById(Guid id);
        void UpdateOrder(OrderUpdateDTO order, Guid id);
        public List<Order> GetAllOrdersForAUser();

    }
}