using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Services.OrderProductRelationService;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class OrderProductRelationController: ControllerBase
    {
        private readonly IOrderProductRelationService _orderProductRelationService;
        private readonly ElectronicsStoreContext _context;

        public OrderProductRelationController(IOrderProductRelationService orderProductRelationService, ElectronicsStoreContext context)
        {
            _orderProductRelationService = orderProductRelationService;
            _context = context;
        }
        
        
        //POST
        [HttpPost("create")]
        public IActionResult Create([FromBody] OrderProductRelationRegisterDTO orderProductRelation)
        {
            _orderProductRelationService.CreateOrderProductRelation(orderProductRelation);
            return Ok();
        }
    }
    
}