using System.Threading.Tasks;
using InsuranceExamGAP_ORM.Core.Models;

namespace InsuranceExamGAP_ORM.Repositories.RepositoryInterfaces
{
    public interface IUserRepository
    {
        User CheckUserPassword(string username, string password);
        Task<User> RegisterUser(User user);
        User GetUser(int userId);

    }
}