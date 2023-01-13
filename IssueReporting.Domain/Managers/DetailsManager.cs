using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;
using static System.Net.Mime.MediaTypeNames;

namespace IssueReporting.Domain.Managers
{
    public class DetailsManager : IDetailsManager
    {
        private readonly ITypeRepository _typeRep;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IissueRepository _issueRepository;


        private readonly IDetailsRepository _detailsRepo;
        private IMapper _mapper { get; }
        public DetailsManager(IDetailsRepository detailsRepo, IMapper mapper,ITypeRepository typeRepository,IApplicationRepository application,IissueRepository iissueRepository)
        {
            _mapper = mapper;
            _detailsRepo = detailsRepo;
            _typeRep= typeRepository;
            _applicationRepository = application;
            _issueRepository = iissueRepository;
        }
        public async Task<IssueDetailDTO> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            var res = await _detailsRepo.GetIssueDetailByTicketIdAsync(ticketId);
            if (res == null)
            {
                throw new ServiceException("Ticket not found");
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
            if (res == null)
            {
                throw new ServiceException("Ticket not found");
            }
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

        public async Task CreateTicketAsync(IssueDetailDTO request)
        {
            var type = await _typeRep.GetTypeByIdAsync(request.TypeId);
            if (type == null)
            {
                throw new ServiceException("Type not exist");
            }

            var application = await _applicationRepository.GetApplicationsByIdAsync(request.ApplicationId);
            if (application == null)
            {
                throw new ServiceException("Application not exist");
            }

            var issue = await _issueRepository.GetIssuesByIssueId (request.IssueId);
            if (issue == null)
            {
                throw new ServiceException("Issue not exist");
            }

            var ticket = _mapper.Map<IssueDetail>(request);

            ticket.CreatedAt=DateTime.Now;
            ticket.LastUpdatedAt = DateTime.Now;


            await _detailsRepo.CreateTicketAsync(ticket);
        }
    }
}
