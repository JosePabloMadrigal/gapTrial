using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;
using InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace InsuranceExamGAP_ORM.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly InsuranceContext _context;
        public ClientRepository(InsuranceContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}