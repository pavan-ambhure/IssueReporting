using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Models.DTOs;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;

namespace IssueReporting.Services.Concrete
{
    public class IssueService : IissueService
    {
        private readonly IissueManager _issueManager = null!;
        private IMapper _mapper { get; }
        public IssueService(IissueManager issueManager, IMapper mapper)
        {
            _mapper = mapper;
            _issueManager = issueManager;
        }
        public async Task CreateIssueAsync(CreateIssueMasterRequest issue)
        {
            var dto = _mapper.Map<IssueMasterDTO>(issue);
            await _issueManager.CreateIssueAsync(dto);
        }

        public async Task<List<IssueMasterResponse>> GetIssuesByAppId(int appId)
        {
            var res = await _issueManager.GetIssuesByAppId(appId);
            return _mapper.Map<List<IssueMasterResponse>>(res);
        }

        public async Task UpdateIssueAsync(UpdateIssueMasterRequest issue)
        {
            var dto = _mapper.Map<IssueMasterDTO>(issue);
            await _issueManager.UpdateIssueAsync(dto);
        }
    }
}
