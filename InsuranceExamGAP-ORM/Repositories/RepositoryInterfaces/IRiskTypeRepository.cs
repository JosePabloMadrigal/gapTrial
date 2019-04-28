using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IRiskTypeRepository
    {
        Task<List<RiskType>> GetRiskTypes();
    }
}