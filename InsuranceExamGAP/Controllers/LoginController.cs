using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceExamGAP.Controllers
{
    [Route("api/login/[controller]")]
    public class LoginController : Controller
    {

        //UI setup
        //TODO 1 Add angular material

        //Backend setup
        //TODO 2 Create ORM database first
        //TODO 3 Create tables for Users, PolicyType, Policy, RiskType, Client, PolicyClient
        //TODO 4 Implement dependency injection
        //TODO 5 Create unit testing project
        //TODO 6 CREATE provider layout Repository Pattern
        //TODO 7 Create integration testing for database and api

        //UI Work 
        //TODO 1 Create Login website 
        //TODO 2 Create left menu to navigation
        //TODO 3 Create Component to display all policies 
        //TODO 4 Create Modal to add and edit policies 
        //TODO 5 Create on the policies table a button to delete policy
        //TODO 6 Create a new component to assign or remove policies to a client.

        //Backend work

        //TODO 7 Add services for Login
        //TODO 8 Create a token for communication
        //TODO 9 Create authorization flags
        //TODO 10 Create services for insurance management 
        //TODO 11 Create policy unit testing when add to a client.

        [HttpPost("[action]")]
        public object Login()
        {
            return 1;
        }

        
    }
}
