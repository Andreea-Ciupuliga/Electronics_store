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
        [HttpGet("byId")]
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
        public IActionResult Create(DeliveryAddressRegisterDTO deliveryAddress)
        {
            _deliveryAddressService.CreateDeliveryAddress(deliveryAddress);
            return Ok();
        }
        
        //PUT
        [HttpPut("update")]
        public IActionResult Update(DeliveryAddressUpdateDTO deliveryAddress, Guid id)
        {
            _deliveryAddressService.UpdateDeliveryAddress(deliveryAddress,id);
            return Ok();
        }
        
        
        //DELETE
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _deliveryAddressService.DeleteDeliveryAddressById(Id);
            return Ok();
        }
        
        
    }
}