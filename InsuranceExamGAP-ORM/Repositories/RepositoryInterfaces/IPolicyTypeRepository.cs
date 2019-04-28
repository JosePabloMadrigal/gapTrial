using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IPolicyTypeRepository
    {
        Task<List<PolicyType>> GetPolicyTypes();
    }
}