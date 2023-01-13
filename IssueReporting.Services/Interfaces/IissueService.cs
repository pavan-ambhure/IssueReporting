using IssueReporting.Contracts.Models.DTOs;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Services.Interfaces
{
    public interface IissueService
    {
        Task<List<IssueMasterResponse>> GetIssuesByAppId(int appId);

        Task CreateIssueAsync(CreateIssueMasterRequest issue);

        Task UpdateIssueAsync(UpdateIssueMasterRequest issue);
    }
}
