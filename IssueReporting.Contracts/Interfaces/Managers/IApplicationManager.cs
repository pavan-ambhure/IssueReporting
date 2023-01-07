using IssueReporting.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Interfaces.Managers
{
    public interface IApplicationManager
    {
        Task<List<ApplicationMasterDTO>> GetApplicationsByTypeIdAsync(int typeId);

        Task CreateApplicationAsync(ApplicationMasterDTO application);

        Task UpdateApplicationAsync(ApplicationMasterDTO application);
    }
}
