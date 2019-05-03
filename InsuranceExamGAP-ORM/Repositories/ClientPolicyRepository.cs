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



        public async Task<List<int>> GetClientPoliciesByClientId(int clientId)
        {
            return await _context.ClientPolicies.Where(cp => cp.ClientId == clientId).Select(cp =>  cp.PolicyId).ToListAsync();
        }

        public async Task<List<ClientPolicy>> AddOrUpdateClientPolicies(ClientPolicies clientPolicies)
        {
            List<ClientPolicy> clientPolicyListSaved = await _context.ClientPolicies.Where(cp => cp.ClientId == clientPolicies.ClientId).ToListAsync();
            List<ClientPolicy> clientPoliciesToAdd = new List<ClientPolicy>();
            List<ClientPolicy> clientPoliciesToDelete = new List<ClientPolicy>();
            if (clientPolicyListSaved.Count > 0)
            {
                clientPolicyListSaved.ForEach(client =>
                {
                    if (clientPolicies.PoliciesIds.Contains(client.PolicyId) == false)
                    {
                        clientPoliciesToDelete.Add(client);
                    }

                });
            }
            clientPolicies.PoliciesIds.ForEach(id =>
            {
                ClientPolicy clientPolicy = clientPolicyListSaved.Find(e => e.ClientId == clientPolicies.ClientId && e.PolicyId == id);
                if (clientPolicy == null)
                {
                    clientPoliciesToAdd.Add(new ClientPolicy{ ClientId = clientPolicies.ClientId, PolicyId = id});
                }

            });
            await _context.ClientPolicies.AddRangeAsync(clientPoliciesToAdd);
            _context.ClientPolicies.RemoveRange(clientPoliciesToDelete);
            await _context.SaveChangesAsync();
            return await _context.ClientPolicies.Where(cp => cp.ClientId == clientPolicies.ClientId).ToListAsync();
        }
    }
}