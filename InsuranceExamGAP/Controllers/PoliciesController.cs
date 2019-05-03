using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceExamGAP_ORM;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace InsuranceExamGAP.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;

        public PoliciesController(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetPolicies()
        {
            return await _policyRepository.GetPolicies();
        }


        // POST: api/Policies/CreatePolicy
        [HttpPost("create")]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {

            try
            {
                return await _policyRepository.UpdatePolicy(policy);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server Error");


            }
            
        }
        // PUT: api/UpdatePolicy
        [HttpPost("update")]
        public async Task<ActionResult<Policy>> UpdatePolicy(Policy policy)
        {
            try
            {
                return await _policyRepository.UpdatePolicy(policy);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server Error");


            }


        }

        

        // DELETE: api/Policies/5
        [HttpDelete("delete/{policyId}")]
        public async Task<ActionResult<Policy>> DeletePolicy(int policyId)
        {
            var policy = await _policyRepository.FindPolicy(policyId);
            if (policy == null)
            {
                return NotFound();
            }

            await _policyRepository.DeletePolicy(policy);
            return policy;
        }

    }
}
