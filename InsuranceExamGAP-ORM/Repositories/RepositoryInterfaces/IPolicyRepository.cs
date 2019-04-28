using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IPolicyRepository
    {
        Task<List<Policy>> GetPolicies();
        Task<Policy> CreatePolicy(Policy policy);
        Task<Policy> UpdatePolicy(Policy policy);
        Task DeletePolicy(Policy policy);
        Task<Policy> FindPolicy(int policyId);
    }
}