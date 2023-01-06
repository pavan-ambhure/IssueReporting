using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IssueReporting.DataAccess.Concrete
{
    public class TypeRepository : ITypeRepository
    {
        IssueReportingContext _context;
        public TypeRepository(IssueReportingContext context)
        {
            _context = context;
        }

        public async Task CreateTypeAsync(TypeMaster type)
        {
            await _context.TypeMasters.AddAsync(type);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TypeMaster>> GetTypeAsync()
        {
            var res = await _context.TypeMasters.ToListAsync();
            return res;
        }
    }
}
