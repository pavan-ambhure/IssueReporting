using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;

namespace IssueReporting.Domain.Managers
{
    public class IssueManager : IissueManager
    {
        private readonly IissueRepository _issueRepo;
        private IMapper _mapper { get; }
        public IssueManager(IissueRepository issueRepo, IMapper mapper)
        {
            _mapper = mapper;
            _issueRepo = issueRepo;
        }
        public async Task CreateIssueAsync(IssueMasterDTO issue)
        {
            var issueEntity = _mapper.Map<IssueMaster>(issue);

            var res = await _issueRepo.GetIssuesByNameAndAppIdAsync(issue.IssueName, issue.ApplicationId);
            if (res != null)
            {
                throw new ServiceException("Issue exist with same name");
            }
            await _issueRepo.CreateIssueAsync(issueEntity);
        }

        public async Task<List<IssueMasterDTO>> GetIssuesByAppId(int appId)
        {
            var res = await _issueRepo.GetIssuesByAppId(appId);
            return _mapper.Map<List<IssueMasterDTO>>(res);
        }

        public async Task UpdateIssueAsync(IssueMasterDTO issue)
        {
            var issueMasterEntity = _mapper.Map<IssueMaster>(issue);

            var issueMaster = await _issueRepo.GetIssuesByIssueId(issue.IssueId);
            if (issue == null)
            {
                throw new ServiceException("Issue not found");
            }
            issue.IssueName = issue.IssueName;
            issue.ApplicationId = issue.ApplicationId;

            await _issueRepo.UpdateIssueAsync(issueMaster);
        }
    }
}
