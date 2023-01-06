using IssueReporting.Contracts.Interfaces.Repositories;
using IssueReporting.DataAccess.Concrete;
using IssueReporting.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.DataAccess.Concrete;


namespace WebApiTemplate.DataAccess.Infrastructure
{
    public static class RepositoryBindings
    {
        /// <summary>
        /// Registers
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IDetailsRepository, DetailsRepository>();
            services.AddScoped<IissueRepository, IssueRepository>();

            services.AddDbContext<IssueReportingContext>();

        }
    }
}
