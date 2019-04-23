using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceExamGAP.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        //TODO Create ORM database first
        //TODO Create tables for Users, PolicyType, Policy, RiskType
        //TODO Implement dependency injection
        //TODO Create unit testing
        //TODO CREATE provider layout Repository Pattern

        //TODO Add services for Login
        //TODO Create a token for communication
        //TODO Create authorization flags
        //TODO Create services for insurance management 

        [HttpPost("[action]")]
        public object Login()
        {
            return 1;
        }

        
    }
}
