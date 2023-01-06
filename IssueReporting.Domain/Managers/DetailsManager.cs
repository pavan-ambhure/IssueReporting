using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Domain.Managers
{
    public class DetailsManager : IDetailsManager
    {
        public Task<IssueDetailDTO> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueDetailDTO>> GetIssuesDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueDetailDTO>> GetIssuesDetailsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueDetails(IssueDetailDTO issueDetail)
        {
            throw new NotImplementedException();
        }
    }
}
