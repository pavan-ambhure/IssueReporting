using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using IssueReporting.DataAccess.Configuration;

namespace IssueReporting.DataAccess.Concrete
{
    public class ApplicationRepository : IApplicationRepository
    {
        IssueReportingContext _context;
        public ApplicationRepository(IssueReportingContext context)
        {
            _context = context;
        }
        public async Task CreateApplicationAsync(ApplicationMaster application)
        {
            await _context.ApplicationMasters.AddAsync(application);
            await _context.SaveChangesAsync();

        }

        public async Task<ApplicationMaster?> GetApplicationsByIdAsync(int appId)
        {
            var res = await _context.ApplicationMasters.FirstOrDefaultAsync(a => a.ApplicationId == appId);
            if (res != null)
            {
                return res;
            }
            return null;
        }

        public async Task<ApplicationMaster?> GetApplicationsByNameAndTypeIdAsync(string appName, int typeId)
        {
            var res = await _context.ApplicationMasters.FirstOrDefaultAsync(a => a.ApplcationName.ToLower() == appName.ToLower() && a.TypeId == typeId);
            if (res != null)
            {
                return res;
            }
            return null;
        }

        public async Task<List<ApplicationMaster>> GetApplicationsByTypeIdAsync(int typeId)
        {
            return await _context.ApplicationMasters.Where(a => a.TypeId == typeId).ToListAsync();
        }

        public async Task UpdateApplicationAsync(ApplicationMaster application)
        {
            _context.ApplicationMasters.Update(application);
            await _context.SaveChangesAsync();
        }
    }
}
