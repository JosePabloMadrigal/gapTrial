using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceExamGAP_ORM.Repositories
{
    public class RiskTypeRepository : IRiskTypeRepository
    {
        private readonly InsuranceContext _context;
        public RiskTypeRepository(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<List<RiskType>> GetRiskTypes()
        {
            return await _context.RiskTypes.ToListAsync();
        }
    }
}