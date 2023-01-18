using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task CreateIssueAsync(IssueMaster issue)
        {
            await _context.IssueMasters.AddAsync(issue);
            await _context.SaveChangesAsync();
        }

        public async Task<List<IssueMaster>> GetIssuesByAppId(int appId)
        {
            var res = await _context.IssueMasters.Where(a => a.ApplicationId == appId).ToListAsync();
            return res;
        }

        public async Task<IssueMaster?> GetIssuesByIssueId(int issueId)
        {
            var res = await _context.IssueMasters.FirstOrDefaultAsync(a => a.IssueId == issueId);
            return res;
        }

        public async Task<IssueMaster> GetIssuesByNameAndAppIdAsync(string issueName, int appId)
        {
            var res = await _context.IssueMasters.FirstOrDefaultAsync(a => a.ApplicationId == appId && a.IssueName == issueName);
            return res;
        }

        public async Task UpdateIssueAsync(IssueMaster issue)
        {
            _context.IssueMasters.Update(issue);
            await _context.SaveChangesAsync();
        }
    }
}
