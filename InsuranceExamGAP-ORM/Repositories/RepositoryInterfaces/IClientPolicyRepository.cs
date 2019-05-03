using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IClientPolicyRepository
    {
        Task<List<int>> GetClientPoliciesByClientId(int clientId);

        Task<List<ClientPolicy>> AddOrUpdateClientPolicies(ClientPolicies clientPolicies);
    }
}