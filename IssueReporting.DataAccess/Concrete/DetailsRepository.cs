using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;

namespace IssueReporting.DataAccess.Concrete
{
    public class DetailsRepository : IDetailsRepository
    {
        IssueReportingContext _context;
        public DetailsRepository(IssueReportingContext context)
        {
            _context = context;
        }
        public Task<IssueDetail> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueDetail>> GetIssuesDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueDetail>> GetIssuesDetailsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueDetails(IssueDetail issueDetail)
        {
            throw new NotImplementedException();
        }
    }
}
