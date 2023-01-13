using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
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
    public class DetailsService : IDetailsService
    {
        private readonly IDetailsManager _detailsManager = null!;
        private IMapper _mapper { get; }
        public DetailsService(IDetailsManager detailsManager, IMapper mapper)
        {
            _mapper = mapper;
            _detailsManager = detailsManager;
        }
        public async Task<IssueDetailResponse> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            var res = await _detailsManager.GetIssueDetailByTicketIdAsync(ticketId);
            return _mapper.Map<IssueDetailResponse>(res);
        }

        public async Task<List<IssueDetailResponse>> GetIssuesDetailsAsync()
        {
            var res = await _detailsManager.GetIssuesDetailsAsync();
            return _mapper.Map<List<IssueDetailResponse>>(res);
        }

        public async Task<List<IssueDetailResponse>> GetIssuesDetailsByUserIdAsync(int userId)
        {
            var res = await _detailsManager.GetIssuesDetailsByUserIdAsync(userId);
            return _mapper.Map<List<IssueDetailResponse>>(res);
        }

        public async Task UpdateIssueDetails(UpdateIssueDetailsRequest issueDetail)
        {
            var ticket = _mapper.Map<IssueDetailDTO>(issueDetail);
            await _detailsManager.UpdateIssueDetails(ticket);
        }

        public async Task CreateTicketAsync(CreateTicketRequest request)
        {
            var ticket = _mapper.Map<IssueDetailDTO>(request);
           await   _detailsManager.CreateTicketAsync(ticket);
        }
    }
}
