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
    public class ClientPolicyController : ControllerBase
    {
        private readonly IClientPolicyRepository _clientPolicyRepository;

        public ClientPolicyController(IClientPolicyRepository clientPolicyRepository)
        {
            _clientPolicyRepository = clientPolicyRepository;
        }

        [HttpGet("getClientPolicies/{clientId}")]
        public async Task<ActionResult<List<int>>> GetClientPoliciesByClientId(int clientId)
        {
            return await _clientPolicyRepository.GetClientPoliciesByClientId(clientId);
        }


        [HttpPost("CreatePolicyClients")]
        public async Task<ActionResult<List<ClientPolicy>>> CreatePolicyClients(ClientPolicies clientPolicy)
        {
            try
            {
                return await _clientPolicyRepository.AddOrUpdateClientPolicies(clientPolicy);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server Error");
            }

        }
    }
}