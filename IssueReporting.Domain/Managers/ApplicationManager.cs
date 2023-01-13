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
        private readonly ITypeRepository _typeRepository;
        private IMapper _mapper { get; }
        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ITypeRepository typeRepository)
        {
            _mapper = mapper;
            _applicationRepository = applicationRepository;
            _typeRepository = typeRepository;
        }
        public async Task CreateApplicationAsync(ApplicationMasterDTO application)
        {
            try
            {
                var type = await _typeRepository.GetTypeByIdAsync(application.TypeId);
                if(type== null)
                {
                    throw new ServiceException("Wrong type");
                }

                var appEntity = _mapper.Map<ApplicationMaster>(application);

                var app = await _applicationRepository.GetApplicationsByNameAndTypeIdAsync(appEntity.ApplcationName,appEntity.TypeId);
                if (app != null)
                {
                    throw new ServiceException("Application exist with same name");
                }

                await _applicationRepository.CreateApplicationAsync(appEntity);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ApplicationMasterDTO>> GetApplicationsByTypeIdAsync(int typeId)
        {
            try
            {
                var applications = await _applicationRepository.GetApplicationsByTypeIdAsync(typeId);
                return _mapper.Map<List<ApplicationMasterDTO>>(applications);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task UpdateApplicationAsync(ApplicationMasterDTO application)
        {
            try
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
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
