using IssueReporting.Contracts.Models;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface IDetailsRepository
    {
        Task<List<IssueDetail>> GetIssuesDetailsAsync();

        Task<IssueDetail> GetIssueDetailByTicketIdAsync(int ticketId);

        Task<List<IssueDetail>> GetIssuesDetailsByUserIdAsync(int userId);

        Task UpdateIssueDetails(IssueDetail issueDetail);
    }
}
