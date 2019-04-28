using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceExamGAP.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyTypeController : ControllerBase
    {
        private readonly IPolicyTypeRepository _policyTypeRepository;
        public PolicyTypeController(IPolicyTypeRepository policyTypeRepository)
        {
            _policyTypeRepository = policyTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolicyType>>> GetPolicyTypes()
        {
            return await _policyTypeRepository.GetPolicyTypes();
        }
    }
}