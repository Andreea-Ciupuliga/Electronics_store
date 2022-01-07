using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ElectronicsStoreContext _context;

        public OrderController(IOrderService orderService,ElectronicsStoreContext context)
        {
            _orderService = orderService;
            _context = context;
        }
        
        //GET
        [HttpGet("byId")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_orderService.GetOrderByOrderId(Id));
        }
        
       
        [HttpGet("allOrders")]
        public IActionResult GetAllOrders() 
        {
            return Ok(_orderService.GetAllOrders());
        }
        
        
        //POST
        [HttpPost("create")]
        public IActionResult Create(OrderRegisterDTO order)
        {
            _orderService.CreateOrder(order);
            return Ok();
        }
        
        //PUT
        [HttpPut("update")]
        public IActionResult Update(OrderUpdateDTO order, Guid id)
        {
            _orderService.UpdateOrder(order,id);
            return Ok();
        }
        
        
        //DELETE
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _orderService.DeleteOrderById(Id);
            return Ok();
        }
    }
}