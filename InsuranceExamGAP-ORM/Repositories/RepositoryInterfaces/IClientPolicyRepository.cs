using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IClientPolicyRepository
    {
        Task<List<ClientPolicy>> GetClientPolicies();

        Task<List<ClientPolicy>> AddOrUpdateClientPolicies(List<ClientPolicy> addClientPolicies,
            List<ClientPolicy> deleteClientPolicies);
    }
}