using IssueReporting.Contracts.Models.DTOs;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Services.Interfaces
{
    public interface IDetailsService
    {
        Task<List<IssueDetailResponse>> GetIssuesDetailsAsync();

        Task<IssueDetailResponse> GetIssueDetailByTicketIdAsync(int ticketId);

        Task<List<IssueDetailResponse>> GetIssuesDetailsByUserIdAsync(int userId);

        Task UpdateIssueDetails(UpdateIssueDetailsRequest issueDetail);
    }
}
