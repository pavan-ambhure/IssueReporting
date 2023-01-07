using IssueReporting.Contracts.Models;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface IApplicationRepository
    {
        Task<List<ApplicationMaster>> GetApplicationsByTypeIdAsync(int typeId);
        Task<ApplicationMaster> GetApplicationsByNameAsync(string appName);
        Task<ApplicationMaster> GetApplicationsByIdAsync(int appId);

        Task CreateApplicationAsync(ApplicationMaster application);

        Task UpdateApplicationAsync(ApplicationMaster application);
    }
}
