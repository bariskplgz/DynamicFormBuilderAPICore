using DynamicFormBuilder.Core.Dtos;
using DynamicFormBuilder.Core.Models;

namespace DynamicFormBuilder.Core.Repositories
{
    public interface IAuthRepository : IGenericRepository<User>
    {
        public Task<User> LoginAsync(string username, string password);
    }
}
