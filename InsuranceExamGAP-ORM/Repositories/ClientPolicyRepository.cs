using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceExamGAP_ORM.Repositories
{
    public class ClientPolicyRepository : IClientPolicyRepository
    {
        private readonly InsuranceContext _context;
        public ClientPolicyRepository(InsuranceContext context)
        {
            _context = context;
        }
        public async Task<List<ClientPolicy>> GetClientPolicies()
        {
            return await _context.ClientPolicies.ToListAsync();
        }

        public async Task<List<ClientPolicy>> AddOrUpdateClientPolicies(List<ClientPolicy> addClientPolicies, List<ClientPolicy> deleteClientPolicies)
        {
            _context.ClientPolicies.AddRange(addClientPolicies);
            _context.ClientPolicies.RemoveRange(deleteClientPolicies);
            _context.SaveChanges();
            return await _context.ClientPolicies.ToListAsync(); ;
        }
    }
}