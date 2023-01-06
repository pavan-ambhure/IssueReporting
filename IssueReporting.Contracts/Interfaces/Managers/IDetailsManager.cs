using IssueReporting.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Interfaces.Managers
{
    public interface IDetailsManager
    {
        Task<List<IssueDetailDTO>> GetIssuesDetailsAsync();

        Task<IssueDetailDTO> GetIssueDetailByTicketIdAsync(int ticketId);

        Task<List<IssueDetailDTO>> GetIssuesDetailsByUserIdAsync(int userId);

        Task UpdateIssueDetails(IssueDetailDTO issueDetail);
    }
}
