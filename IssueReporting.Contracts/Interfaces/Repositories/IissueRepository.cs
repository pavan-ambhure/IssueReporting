using IssueReporting.Contracts.Models;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface IissueRepository
    {
        Task<IssueMaster> GetIssuesByAppId(int appId);

        Task CreateIssueAsync(IssueMaster issue);

        Task UpdateIssueAsync(IssueMaster issue);
    }
}
