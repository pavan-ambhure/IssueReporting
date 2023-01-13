using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Models.DTOs;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;

namespace IssueReporting.Services.Concrete
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationManager _applicationManager = null!;
        private IMapper _mapper { get; }
        public ApplicationService(IApplicationManager applicationManager, IMapper mapper)
        {
            _mapper = mapper;
            _applicationManager = applicationManager;
        }

        public async Task<List<ApplicationMasterResponse>> GetApplicationsByTypeIdAsync(int typeId)
        {
            var res = await _applicationManager.GetApplicationsByTypeIdAsync(typeId);
            return _mapper.Map<List<ApplicationMasterResponse>>(res);
        }

        public async Task CreateApplicationAsync(CreateApplicationRequest application)
        {
            var appMaster = _mapper.Map<ApplicationMasterDTO>(application);
            await _applicationManager.CreateApplicationAsync(appMaster);
        }

        public async Task UpdateApplicationAsync(UpdateApplicationRequest application)
        {
            var appMaster = _mapper.Map<ApplicationMasterDTO>(application);
            await _applicationManager.UpdateApplicationAsync(appMaster);
        }
    }
}
