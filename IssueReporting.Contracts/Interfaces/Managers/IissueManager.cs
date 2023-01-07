using IssueReporting.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Interfaces.Managers
{
    public interface IissueManager
    {
        Task<List<IssueMasterDTO>> GetIssuesByAppId(int appId);

        Task CreateIssueAsync(IssueMasterDTO issue);

        Task UpdateIssueAsync(IssueMasterDTO issue);
    }
}
