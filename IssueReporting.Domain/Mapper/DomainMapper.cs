using AutoMapper;
using IssueReporting.Contracts.Models;
using IssueReporting.Contracts.Models.DTOs;
using WebApiTemplate.Contracts.Models;
using WebApiTemplate.Contracts.Models.DTOs;

namespace WebApiTemplate.Domain.Mapper
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<UserMaster, UserDTO>().ReverseMap();
            CreateMap<TypeMaster, TypeDTO>().ReverseMap();
        }
    }
}
