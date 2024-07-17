using DynamicFormBuilder.Core.Models;

namespace DynamicFormBuilder.Core.Repositories
{
    public interface IFormRepository : IGenericRepository<Form>
    {
        public Task<Form> GetByIdWithFieldsAsync(int id);
    }
}
