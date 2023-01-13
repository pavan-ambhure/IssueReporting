using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;

namespace IssueReporting.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<List<IssueDetailResponse>> GetIssuesDetailsAsync();

        Task<IssueDetailResponse> GetIssueDetailByTicketIdAsync(int ticketId);

        Task<List<IssueDetailResponse>> GetIssuesDetailsByUserIdAsync(int userId);

        Task UpdateIssueDetails(UpdateIssueDetailsRequest issueDetail);

        Task CreateTicketAsync(CreateTicketRequest request);
    }
}
