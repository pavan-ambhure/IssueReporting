using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ApplicationMaster> GetApplicationsByIdAsync(int appId)
        {
            return await _context.ApplicationMasters.FirstOrDefaultAsync(a => a.ApplicationId == appId);
        }

        public async Task<ApplicationMaster> GetApplicationsByNameAsync(string appName)
        {
            return await _context.ApplicationMasters.FirstOrDefaultAsync(a => a.ApplcationName == appName);
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
