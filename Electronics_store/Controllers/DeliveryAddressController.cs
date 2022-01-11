using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Services.DeliveryAddressService;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class DeliveryAddressController : ControllerBase
    {
        private readonly IDeliveryAddressService _deliveryAddressService;
        private readonly ElectronicsStoreContext _context;

        public DeliveryAddressController(IDeliveryAddressService deliveryAddressService, ElectronicsStoreContext context)
        {
            _deliveryAddressService = deliveryAddressService;
            _context = context;
        }
        
        //GET
        [HttpGet("byId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_deliveryAddressService.GetDeliveryAddressByDeliveryAddressId(Id));
        }
        
       
        [HttpGet("allDeliveryAddresses")]
        public IActionResult GetAllDeliveryAddresses() 
        {
            return Ok(_deliveryAddressService.GetAllDeliveryAddresses());
        }
        
        
        //POST
        [HttpPost("create")]
        public IActionResult Create([FromBody] DeliveryAddressRegisterDTO deliveryAddress)
        {
            _deliveryAddressService.CreateDeliveryAddress(deliveryAddress);
            return Ok();
        }
        
        //PUT
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] DeliveryAddressUpdateDTO deliveryAddress, Guid id)
        {
            _deliveryAddressService.UpdateDeliveryAddress(deliveryAddress,id);
            return Ok();
        }
        
        
        //DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(Guid Id)
        {
            _deliveryAddressService.DeleteDeliveryAddressById(Id);
            return Ok();
        }
        
        
    }
}