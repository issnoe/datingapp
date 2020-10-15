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

            return Ok( _mapper.Map<IEnumerable<MemberDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(string name)
        {
            // Bad way to run queries 
            // return  _mapper.Map<MemberDto>(await _userRepository.GetUserByIdAsync(id));

             // Enchange in SQL queries
           return  _mapper.Map<MemberDto>(await _userRepository.GetMemberAsync(name));
        }
    }
}