using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using API.DTOs;
using AutoMapper;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // Bad way to run queries 
            // var users = await _userRepository.GetUsersAsync();

            // Enchange in SQL queries
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }
        //[HttpGet("id{username}")] If you can add more endpoint
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            // Bad way to run queries 
            // return  _mapper.Map<MemberDto>(await _userRepository.GetUserByIdAsync(id));

            // Enchange in SQL queries
            return await _userRepository.GetMemberAsync(username);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            // Obtener el usuario por medio del TOKEN :) 
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Get User
            var user = await _userRepository.GetUserByUsernameAsync(username);

            // Merge bewten param memen¡ber and user in the database
            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}