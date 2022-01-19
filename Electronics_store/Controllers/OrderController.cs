using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Services.OrderService;
using Electronics_store.Utilities.Atttributes;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ElectronicsStoreContext _context;

        public OrderController(IOrderService orderService, ElectronicsStoreContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        //GET
        [AuthorizationAttribute(Role.Admin)]
        [HttpGet("byId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_orderService.GetOrderByOrderId(Id));
        }

        [AuthorizationAttribute(Role.Admin)]
        [HttpGet("allOrders")]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [AuthorizationAttribute(Role.Admin)]
        [HttpGet("allOrdersForAUser/{id}")]
        public IActionResult GetAllOrdersForAUser(Guid userId)
        {
            return Ok(_orderService.GetAllOrdersForAUser(userId));
        }


        //POST
        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderRegisterDTO order)
        {
            _orderService.CreateOrder(order);
            return Ok();
        }

        //PUT
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] OrderUpdateDTO order, Guid id)
        {
            _orderService.UpdateOrder(order, id);
            return Ok();
        }


        //DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(Guid Id)
        {
            _orderService.DeleteOrderById(Id);
            return Ok();
        }
    }
}