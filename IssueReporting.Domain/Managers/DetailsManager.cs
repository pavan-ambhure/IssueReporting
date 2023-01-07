using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;

namespace IssueReporting.Domain.Managers
{
    public class DetailsManager : IDetailsManager
    {
        private readonly IDetailsRepository _detailsRepo;
        private IMapper _mapper { get; }
        public DetailsManager(IDetailsRepository detailsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _detailsRepo = detailsRepo;
        }
        public async Task<IssueDetailDTO> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            var res = await _detailsRepo.GetIssueDetailByTicketIdAsync(ticketId);
            if (res == null)
            {
                return new IssueDetailDTO();
            }
            return _mapper.Map<IssueDetailDTO>(res);
        }

        public async Task<List<IssueDetailDTO>> GetIssuesDetailsAsync()
        {
            var res = await _detailsRepo.GetIssuesDetailsAsync();
            return _mapper.Map<List<IssueDetailDTO>>(res);
        }

        public async Task<List<IssueDetailDTO>> GetIssuesDetailsByUserIdAsync(int userId)
        {
            var res = await _detailsRepo.GetIssuesDetailsByUserIdAsync(userId);
            return _mapper.Map<List<IssueDetailDTO>>(res);
        }

        public async Task UpdateIssueDetails(IssueDetailDTO issueDetail)
        {
            var issueEntity = _mapper.Map<IssueDetail>(issueDetail);

            var issue = await _detailsRepo.GetIssueDetailByTicketIdAsync(issueDetail.IssueId);
            if (issue == null)
            {
                throw new ServiceException("Ticket not found");
            }
            issue.Status = issueDetail.Status;
            issue.LastUpdatedAt = issueDetail.LastUpdatedAt;

            await _detailsRepo.UpdateIssueDetails(issue);
        }
    }
}
