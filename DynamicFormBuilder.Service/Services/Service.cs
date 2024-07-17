using DynamicFormBuilder.Core.Repositories;
using DynamicFormBuilder.Core.Responses;
using DynamicFormBuilder.Core.Services;
using System.Linq.Expressions;

namespace DynamicFormBuilder.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public Service(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }


        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public async Task<ApiResponse<List<T>>> GetAllAsync()
        {
            ApiResponse<List<T>> response = new()
            {
                Data = await _repository.GetAllAsync()
            };
            return response;
        }

        public async Task<ApiResponse<T>> GetByIdAsync(int id)
        {
            ApiResponse<T> response = new()
            {
                Data = await _repository.GetByIdAsync(id)
            };
            return response;
        }
    }
}