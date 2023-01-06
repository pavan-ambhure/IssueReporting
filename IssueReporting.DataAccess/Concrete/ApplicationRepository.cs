using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;
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
        public Task CreateApplicationAsync(ApplicationMaster application)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationMaster> GetApplicationsByTypeIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationAsync(ApplicationMaster application)
        {
            throw new NotImplementedException();
        }
    }
}
