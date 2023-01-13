using AutoMapper;
using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.Contracts.Models;
using WebApiTemplate.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;

namespace IssueReporting.Domain.Managers
{
    public class TypeManager : ITypeManager
    {
        private readonly ITypeRepository _typeRepository;
        private IMapper _mapper { get; }
        public TypeManager(ITypeRepository typeRepository, IMapper mapper)
        {
            _mapper= mapper;
            _typeRepository= typeRepository;
        }

        public async Task<List<TypeDTO>> GetTypeAsync()
        {
            var type = await _typeRepository.GetTypeAsync();
            return _mapper.Map<List<TypeDTO>>(type);
        }

        public async Task CreateTypeAsync(string typeName)
        {
            TypeMaster type = new TypeMaster()
            {
                TypeName = typeName,
            };

            var existingType=await _typeRepository.GetTypeByNameAsync(typeName);
            if (existingType.TypeName != null) {
                throw new ServiceException("Type name already exist");
            }

           await _typeRepository.CreateTypeAsync(type);
        }
    }
}
