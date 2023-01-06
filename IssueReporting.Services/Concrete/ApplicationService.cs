using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Services.Concrete
{
    public class ApplicationService :IApplicationService
    {
        private readonly IApplicationManager _applicationManager = null!;
        private IMapper _mapper { get; }
        public ApplicationService(IApplicationManager applicationManager, IMapper mapper)
        {
            _mapper = mapper;
            _applicationManager = applicationManager;
        }

        public Task<ApplicationMasterResponse> GetApplicationsByTypeIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task CreateApplicationAsync(CreateApplicationRequest application)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApplicationAsync(UpdateApplicationRequest application)
        {
            throw new NotImplementedException();
        }
    }
}
