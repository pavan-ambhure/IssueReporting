using IssueReporting.Contracts.Models;
using IssueReporting.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.Contracts.Models;

namespace WebApiTemplate.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly IssueReportingContext _db;
        public UserRepository(IssueReportingContext db) 
        {
            _db= db;
        }
        public async Task<UserMaster> CreateAsync(UserMaster entity)
        {
            _db.UserMasters.Add(entity);
            await _db.SaveChangesAsync();
            return await GetUserbyEmailAsync(entity.UserEmail);
        }

        public async Task<UserMaster> GetUserAsync(UserMaster entity)
        {
            var user = await _db.UserMasters.FirstOrDefaultAsync(a => a.UserEmail == entity.UserEmail 
            && a.Password==entity.Password);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<UserMaster> GetUserbyEmailAsync(string email)
        {
            var user = await _db.UserMasters.SingleOrDefaultAsync(a => a.UserEmail==email);

            if (user == null)
            {
                return new UserMaster();
            }

            return user;
        }
    }
}
