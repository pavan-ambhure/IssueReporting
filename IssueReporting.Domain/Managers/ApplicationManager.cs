using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;

namespace IssueReporting.Domain.Managers
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly IApplicationRepository _applicationRepository;
        private IMapper _mapper { get; }
        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
        }
        public async Task CreateApplicationAsync(ApplicationMasterDTO application)
        {
            var appEntity = _mapper.Map<ApplicationMaster>(application);

            var app = await _applicationRepository.GetApplicationsByNameAsync(appEntity.ApplcationName);
            if (app != null)
            {
                throw new ServiceException("Application exist with same email");
            }
            await _applicationRepository.CreateApplicationAsync(appEntity);
        }

        public async Task<List<ApplicationMasterDTO>> GetApplicationsByTypeIdAsync(int typeId)
        {
            var applications = await _applicationRepository.GetApplicationsByTypeIdAsync(typeId);
            return _mapper.Map<List<ApplicationMasterDTO>>(applications);

        }

        public async Task UpdateApplicationAsync(ApplicationMasterDTO application)
        {
            var appEntity = _mapper.Map<ApplicationMaster>(application);

            var app = await _applicationRepository.GetApplicationsByIdAsync(appEntity.ApplicationId);
            if (app == null)
            {
                throw new ServiceException("Application not found");
            }
            app = new ApplicationMaster()
            {
                ApplicationId = appEntity.ApplicationId,
                ApplcationName = appEntity.ApplcationName,
                TypeId = appEntity.TypeId,

            };
            await _applicationRepository.UpdateApplicationAsync(app);
        }
    }
}
