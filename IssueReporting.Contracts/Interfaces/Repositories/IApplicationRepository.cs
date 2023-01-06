using IssueReporting.Contracts.Models;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface IApplicationRepository
    {
        Task<ApplicationMaster> GetApplicationsByTypeIdAsync(int typeId);

        Task CreateApplicationAsync(ApplicationMaster application);

        Task UpdateApplicationAsync(ApplicationMaster application);
    }
}
