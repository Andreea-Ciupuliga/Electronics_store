using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ElectronicsStoreContext _context;

        public UserController(IUserService userService, ElectronicsStoreContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetById(Guid Id)
        {
            var result = _userService.GetDataByUserId(Id);
            return Ok(result);
        }
        
        [HttpPost("create")]
        public IActionResult Create(UserDTO user)
        {
            _userService.CreateUser(user);
            //ar trebui sa folosim context ca sa adaugam userul in baza de date
            return Ok();
        }
    }
}