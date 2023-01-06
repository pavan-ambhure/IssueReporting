using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Services.Concrete
{
    public class DetailsService : IDetailsService
    {
        public Task<IssueDetailResponse> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueDetailResponse>> GetIssuesDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueDetailResponse>> GetIssuesDetailsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueDetails(UpdateIssueDetailsRequest issueDetail)
        {
            throw new NotImplementedException();
        }
    }
}
