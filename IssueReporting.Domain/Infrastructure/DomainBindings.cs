using IssueReporting.Contracts.Interfaces.Managers;
using IssueReporting.Domain.Managers;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Contracts.Interfaces.Managers;
using WebApiTemplate.Domain.Managers;

namespace WebApiTemplate.Domain.Infrastructure
{
    public class DomainBindings
    {
        /// <summary>
        /// Registers
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ITypeManager, TypeManager>();

            services.AddScoped<IApplicationManager, ApplicationManager>();
            services.AddScoped<IDetailsManager, DetailsManager>();
            services.AddScoped<IissueManager, IssueManager>();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
