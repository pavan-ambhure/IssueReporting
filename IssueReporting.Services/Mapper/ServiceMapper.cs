﻿using AutoMapper;
using IssueReporting.Contracts.Models.DTOs;
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
        }
    }
}
