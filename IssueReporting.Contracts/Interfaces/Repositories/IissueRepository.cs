using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface IissueRepository
    {
        Task<List<IssueMaster>> GetIssuesByAppId(int appId);
        Task<IssueMaster> GetIssuesByIssueId(int issueId);

        Task CreateIssueAsync(IssueMaster issue);

        Task UpdateIssueAsync(IssueMaster issue);

        Task<IssueMaster> GetIssuesByNameAndAppIdAsync(string issueName, int appId);
    }
}
