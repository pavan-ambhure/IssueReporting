using AutoMapper;
using IssueReporting.Contracts.Models.DTOs;
using IssueReporting.Services.Contract.Request;
using IssueReporting.Services.Contract.Response;
using WebApiTemplate.Contracts.Models.DTOs;
using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Contract.Response;

namespace WebApiTemplate.Services.Mapper
{
    public class ServiceMapper :Profile
    {
        public ServiceMapper()
        {
            CreateMap<CreateUserRequest, UserDTO>().ReverseMap();
            CreateMap<UserResponse, UserDTO>().ReverseMap();
            CreateMap<UserLoginRequest, UserDTO>().ReverseMap();

            CreateMap<TypeResponse, TypeDTO>().ReverseMap();

            CreateMap<ApplicationMasterResponse, ApplicationMasterDTO>().ReverseMap();
            CreateMap<CreateApplicationRequest, ApplicationMasterDTO>().ReverseMap();
            CreateMap<UpdateApplicationRequest, ApplicationMasterDTO>().ReverseMap();

            CreateMap<IssueDetailResponse, IssueDetailDTO>().ReverseMap();
            CreateMap<UpdateIssueDetailsRequest, IssueDetailDTO>().ReverseMap();
            CreateMap<CreateTicketRequest, IssueDetailDTO>().ReverseMap();

            CreateMap<CreateIssueMasterRequest, IssueMasterDTO>().ReverseMap();
            CreateMap<IssueMasterResponse, IssueMasterDTO>().ReverseMap();
            CreateMap<UpdateIssueMasterRequest, IssueMasterDTO>().ReverseMap();
        }
    }
}
