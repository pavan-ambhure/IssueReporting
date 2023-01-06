using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Domain.Managers
{
    public class IssueManager : IissueManager
    {
        public Task CreateIssueAsync(IssueMasterDTO issue)
        {
            throw new NotImplementedException();
        }

        public Task<IssueMasterDTO> GetIssuesByAppId(int appId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueAsync(IssueMasterDTO issue)
        {
            throw new NotImplementedException();
        }
    }
}
