using DynamicFormBuilder.Core.Models;

namespace DynamicFormBuilder.Core.Services
{
    public interface IFormService : IService<Form>
    {
        public Task<Form> GetByIdWithFieldsAsync(int id);
    }
}
