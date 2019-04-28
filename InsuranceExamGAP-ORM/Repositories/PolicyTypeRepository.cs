using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceExamGAP_ORM.Repositories
{
    public class PolicyTypeRepository : IPolicyTypeRepository
    {
        private readonly InsuranceContext _context;
        public PolicyTypeRepository(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<List<PolicyType>> GetPolicyTypes()
        {
            return await _context.PolicyTypes.ToListAsync();
        }
    }
}