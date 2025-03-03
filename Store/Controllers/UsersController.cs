﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        IUserService _iuserservice;
        IMapper _imapper;

      
        public UsersController(IUserService iuserservice,  IMapper imapper,ILogger<UsersController> logger)
        {
           _iuserservice = iuserservice;
            _imapper = imapper;
            _logger = logger;
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> GetById(int id)
        {
           User user= await _iuserservice.GetById(id);
            GetUserDTO userDTO = _imapper.Map<User, GetUserDTO>(user);
            if (userDTO == null)
                return NoContent();
            return Ok(userDTO);
        }

        // POST api/<UsersController>0w
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<GetUserDTO>> PostLogin([FromQuery] string username,string password)
        {
            
            User user = await _iuserservice.PostLoginS(username, password);
            GetUserDTO userDTO=_imapper.Map<User,GetUserDTO>(user);
            if (userDTO != null) {
                _logger.LogCritical($"Login with user name - {username} and password - {password}");
                return Ok(userDTO);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostNewUser([FromBody] UserDTO user)
        {
            User user1 = _imapper.Map<UserDTO, User>(user);
            User newUser =  await _iuserservice.Post(user1);
            if (newUser == null)
                return BadRequest();
            UserDTO newUserDTO = _imapper.Map<User, UserDTO>(newUser);
            if (newUserDTO != null)
                return Ok(newUserDTO);
                //return CreatedAtAction(nameof(GetById),new { id = newUser.Id }, newUser);
            return NoContent();

        }

        [HttpPost]
        [Route("password")]
        public int PostOnChange([FromBody] string password)
        {
            int result = _iuserservice.CheckPassword(password);
                return result;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO user)
        {
            User user1 = _imapper.Map<UserDTO, User>(user);
          await _iuserservice.Put(id, user1);
        }

     
    }
}
