using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceExamGAP.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //UI setup


        //Backend setup
        //TODO 2 -- Create ORM database first
        //TODO 3 -- Create tables for Users, PolicyType, Policy, RiskType, Client, PolicyClient
        //TODO 4 -- Implement dependency injection
        //TODO 5 -- Create unit testing project
        //TODO 6 -- CREATE provider layout Repository Pattern
        //TODO 7  Create integration testing for database and api

        //UI Work 
        //TODO 1 Create Login website 
        //TODO 2 Create left menu to navigation
        //TODO 3 Create Component to display all policies 
        //TODO 4 Create Modal to add and edit policies 
        //TODO 5 Create on the policies table a button to delete policy
        //TODO 6 Create a new component to assign or remove policies to a client.

        //Backend work

        //TODO 7 -- Add services for Login
        //TODO 8 Create a token for communication
        //TODO 9 Create authorization flags
        //TODO 10 Create services for insurance management 
        //TODO 11 Create policy unit testing when add to a client.

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            user = await _userRepository.RegisterUser(user);
            if (user == null)
            {
                return StatusCode(500, "Username exists");
            }
            return user;
        }
        [HttpGet("getUser/{userId}")]
        public ActionResult<User> GetUser(int userId)
        {
            return _userRepository.GetUser(userId);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<User> Login(User user)
        {
            return _userRepository.CheckUserPassword(user.UserName, user.Password);
        }
    }
}
