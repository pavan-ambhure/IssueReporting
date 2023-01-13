using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace IssueReporting.DataAccess.Concrete
{
    public class DetailsRepository : IDetailsRepository
    {
        IssueReportingContext _context;
        public DetailsRepository(IssueReportingContext context)
        {
            _context = context;
        }

        public async Task CreateTicketAsync(IssueDetail request)
        {
            await _context.IssueDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<IssueDetail> GetIssueDetailByTicketIdAsync(int ticketId)
        {
            return await _context.IssueDetails.FirstOrDefaultAsync(a => a.TicketId == ticketId);
        }

        public async Task<List<IssueDetail>> GetIssuesDetailsAsync()
        {
            return await _context.IssueDetails
                .Include(a => a.Type)
                .Include(a=>a.Application)
                .Include(a=>a.Issue)
                .ToListAsync();
        }

        public async Task<List<IssueDetail>> GetIssuesDetailsByUserIdAsync(int userId)
        {
            return await _context.IssueDetails.Where(a => a.CreatedBy == userId).ToListAsync();
        }

        public async Task UpdateIssueDetails(IssueDetail issueDetail)
        {
             _context.IssueDetails.Update(issueDetail);
            await _context.SaveChangesAsync();
        }
    }
}
