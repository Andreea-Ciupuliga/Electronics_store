using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Services.UserService;
using Electronics_store.Utilities.Atttributes;
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

        //endpointul de autentificare trebuie sa fie accesibil tuturor
        [HttpPost("authenticate")]
        public IActionResult Authentificate(UserLoginDTO user)
        {
            var response = _userService.Authentificate(user);

            if (response == null) //adica nu avem userul in baza de date
            {
                return BadRequest(new {Message = "Username or Password is invalid!"});
            }

            return Ok(response);
        }

        //[AuthorizationAttribute(Role.Admin)]
        [HttpGet("byId/{id}")]
        public IActionResult GetByIdWithDto(Guid Id)
        {
            return Ok(_userService.GetUserByUserId(Id));
        }

        //[AuthorizationAttribute(Role.Admin)]
        [HttpGet("allUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }
        
        [HttpGet("GetAllOrdersForAUser")]
        public IActionResult GetAllOrdersForAUser()
        {
            return Ok(_userService.GetAllOrdersForAUser());
        }

        //[AuthorizationAttribute(Role.Admin)]
        [HttpGet("byname")]
        public IActionResult GetAllUsersByName(string name)
        {
            return Ok(_userService.GetAllUsersByName(name));
        }


        //POST
        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] UserRegisterDTO user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
        
        [HttpPost("createAdmin")]
        public IActionResult CreateAdmin([FromBody] UserRegisterDTO user)
        {
            _userService.CreateAdmin(user);
            return Ok();
        }

        //PUT
        [AuthorizationAttribute(Role.User,Role.Admin)]
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] UserRegisterDTO user, Guid id)
        {
            _userService.UpdateUser(user, id);
            return Ok();
        }


        //DELETE
        //[AuthorizationAttribute(Role.Admin)]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(Guid Id)
        {
            _userService.DeleteUserById(Id);
            return Ok();
        }
    }
}