using AutoMapper;
using IssueReporting.Contracts.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebApiTemplate.Contracts.Enums;
using WebApiTemplate.Contracts.Interfaces.Managers;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.Contracts.Models.DTOs;
using WebApiTemplate.Domain.Errors;

namespace WebApiTemplate.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private IMapper _mapper { get; }
        public UserManager(IConfiguration config, IUserRepository userRepository, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO UserDto)
        {
            var userEntity = _mapper.Map<UserMaster>(UserDto);

            var user = await _userRepository.GetUserbyEmailAsync(userEntity.UserEmail);
            if (user != null)
            {
                throw new ServiceException("User Exist with same email");
            }
            user = await _userRepository.CreateAsync(userEntity);
            return _mapper.Map<UserDTO>(UserDto);
        }

        public async Task<string> AuthenticateAsync(UserDTO UserDto)
        {

            var userEntity = _mapper.Map<UserMaster>(UserDto);

            var user = await _userRepository.GetUserAsync(userEntity);
            if (user == null)
            {
                throw new ServiceException("User not found");
            }
            var token = GenerateToken(user);
            return token;

        }

        // To generate token
        private string GenerateToken(UserMaster user)
        {

            String role = ((UserRole)user.Role).ToString();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(user)),
                new Claim(ClaimTypes.Role,role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
