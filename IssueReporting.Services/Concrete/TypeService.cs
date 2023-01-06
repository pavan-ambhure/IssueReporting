using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Services.Contract.Response;
using IssueReporting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Interfaces.Managers;
using WebApiTemplate.Contracts.Models.DTOs;
using WebApiTemplate.Services.Contract.Response;

namespace IssueReporting.Services.Concrete
{
    public class TypeService : ITypeService
    {
        private readonly ITypeManager _typeManager = null!;
        private IMapper _mapper { get; }
        public TypeService(ITypeManager typeManager, IMapper mapper )
        {
            _mapper= mapper;    
            _typeManager = typeManager;
        }
        public async Task<List<TypeResponse>> GetTypeAsync()
        {
            var typeDto = await _typeManager.GetTypeAsync();
            return _mapper.Map<List<TypeResponse>>(typeDto);
        }

        public async Task CreateTypeAsync(string typeName)
        {
             await _typeManager.CreateTypeAsync(typeName);            
        }
    }
}
