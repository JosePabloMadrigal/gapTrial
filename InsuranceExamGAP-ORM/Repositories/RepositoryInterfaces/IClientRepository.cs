using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
    }
}