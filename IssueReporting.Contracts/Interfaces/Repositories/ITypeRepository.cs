using IssueReporting.Contracts.Models;

namespace IssueReporting.Contracts.Interfaces.Repositories
{
    public interface ITypeRepository
    {
        Task<List<TypeMaster>> GetTypeAsync();
        Task CreateTypeAsync(TypeMaster type);
        Task<TypeMaster> GetTypeByNameAsync(string name);
        Task<TypeMaster?> GetTypeByIdAsync(int id);
    }
}
