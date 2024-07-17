using DynamicFormBuilder.Core.Models;

namespace DynamicFormBuilder.Core.Services
{
    public interface IAuthService
    {
        public Task<User> LoginAsync(string username, string password);
        public string GenerateJWT(string username);
    }
}
