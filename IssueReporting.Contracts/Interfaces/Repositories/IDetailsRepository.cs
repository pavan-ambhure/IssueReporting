using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface IDetailsRepository
    {
        Task<List<IssueDetail>> GetIssuesDetailsAsync();

        Task<IssueDetail> GetIssueDetailByTicketIdAsync(int ticketId);

        Task<List<IssueDetail>> GetIssuesDetailsByUserIdAsync(int userId);

        Task UpdateIssueDetails(IssueDetail issueDetail);
        Task CreateTicketAsync(IssueDetail request);
    }
}
