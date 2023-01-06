using FluentValidation;
using IssueReporting.Services.Concrete;
using IssueReporting.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Services.Concrete;
using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Interfaces;
using WebApiTemplate.Services.Validation;

namespace WebApiTemplate.Services.Infrastructure
{
    public class ServiceBindings
    {
        /// <summary>
        /// Registers
        /// </summary>
        public static void Register(IServiceCollection services)
        {

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IDetailsService, DetailsService>();
            services.AddScoped<IissueService, IssueService>();

            #endregion

            #region Automaapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Validators
            services.AddScoped<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
            services.AddScoped<IValidator<UserLoginRequest>, UserLoginRequestValidator>();
            #endregion
        }
    }
}
