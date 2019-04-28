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
    public class RiskTypeController : ControllerBase
    {
        private readonly IRiskTypeRepository _riskTypeRepository;
        public RiskTypeController(IRiskTypeRepository riskTypeRepository)
        {
            _riskTypeRepository = riskTypeRepository;
        }
        [HttpGet]
        
        public async Task<ActionResult<List<RiskType>>> GetPolicies()
        {
            return await _riskTypeRepository.GetRiskTypes();
        }
    }
}