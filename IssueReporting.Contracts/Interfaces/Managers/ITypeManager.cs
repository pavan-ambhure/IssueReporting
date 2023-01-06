using IssueReporting.Contracts.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Interfaces.Managers
{
    public interface ITypeManager
    {
        Task<List<TypeDTO>> GetTypeAsync();
        Task CreateTypeAsync(string typeName);
    }
}
