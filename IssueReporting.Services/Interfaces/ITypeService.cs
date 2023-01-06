using IssueReporting.Services.Contract.Response;
using WebApiTemplate.Services.Contract.Request;
using WebApiTemplate.Services.Contract.Response;

namespace IssueReporting.Services.Interfaces
{
    public interface ITypeService
    {
        Task<List<TypeResponse>> GetTypeAsync();
        Task CreateTypeAsync(string typeName);
    }
}
