using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Domain.Managers
{
    public class ApplicationManager : IApplicationManager
    {
        public Task CreateApplicationAsync(ApplicationMasterDTO application)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationMasterDTO> GetApplicationsByTypeIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationAsync(ApplicationMasterDTO application)
        {
            throw new NotImplementedException();
        }
    }
}
