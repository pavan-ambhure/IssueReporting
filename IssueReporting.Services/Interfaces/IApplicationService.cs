using IssueReporting.Contracts.Models.DTOs;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;

namespace IssueReporting.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<List<ApplicationMasterResponse>> GetApplicationsByTypeIdAsync(int typeId);

        Task CreateApplicationAsync(CreateApplicationRequest application);

        Task UpdateApplicationAsync(UpdateApplicationRequest application);
    }
}
