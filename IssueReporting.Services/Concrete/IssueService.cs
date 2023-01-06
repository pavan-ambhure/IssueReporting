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
    public class IssueService : IissueService
    {
        public Task CreateIssueAsync(CreateIssueMasterRequest issue)
        {
            throw new NotImplementedException();
        }

        public Task<IssueMasterResponse> GetIssuesByAppId(int appId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueAsync(UpdateIssueMasterRequest issue)
        {
            throw new NotImplementedException();
        }
    }
}
