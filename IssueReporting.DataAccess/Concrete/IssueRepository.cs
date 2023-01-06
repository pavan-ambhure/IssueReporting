using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;

namespace IssueReporting.DataAccess.Concrete
{
    public class IssueRepository : IissueRepository
    {

        IssueReportingContext _context;
        public IssueRepository(IssueReportingContext context)
        {
            _context = context;
        }
        public Task CreateIssueAsync(IssueMaster issue)
        {
            throw new NotImplementedException();
        }

        public Task<IssueMaster> GetIssuesByAppId(int appId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueAsync(IssueMaster issue)
        {
            throw new NotImplementedException();
        }
    }
}
