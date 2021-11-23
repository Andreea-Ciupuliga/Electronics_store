using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Services.UserService;
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

        //GET
        [HttpGet("byId")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_userService.GetUserByUserId(Id));
        }
        
        [HttpGet("allUsers")]
        public  IActionResult GetAllUsers() 
        {
            return Ok(_userService.GetAllUsers());
        }
        
        
        [HttpGet("byname")]
        public IActionResult GetAllUsersByName(string name)
        {
            return Ok(_userService.GetAllUsersByName(name));
        }
        
        
        //POST
        [HttpPost("create")]
        public IActionResult Create(RegisterUserDTO user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
        
        //PUT
        [HttpPut("updateUser")]
        public IActionResult Update(RegisterUserDTO user, Guid id)
        {
            _userService.UpdateUser(user, id);
            return Ok();
        }
        
        
        //DELETE
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _userService.DeleteUserById(Id);
            return Ok();
        }
    }
}