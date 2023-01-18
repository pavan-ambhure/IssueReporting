using IssueReporting.Contracts.Models;
using WebApiTemplate.Contracts.Models;

namespace WebApiTemplate.Contracts.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserMaster?> CreateAsync(UserMaster entity);

        Task<UserMaster?> GetUserbyEmailAsync(string email);

        Task<UserMaster?> GetUserAsync(UserMaster entity);
    }
}
