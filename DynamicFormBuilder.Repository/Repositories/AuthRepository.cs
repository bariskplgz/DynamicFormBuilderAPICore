using DynamicFormBuilder.API.Context;
using DynamicFormBuilder.API.Repositories;
using DynamicFormBuilder.Core.Models;
using DynamicFormBuilder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormBuilder.Repository.Repositories
{
    public class AuthRepository : GenericRepository<User>, IAuthRepository
    {
        protected readonly AppDbContext _context;
        public AuthRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _context.Users
                                 .Where(u => u.Username == username && u.Password == password)
                                 .FirstOrDefaultAsync();
        }
    }
}
