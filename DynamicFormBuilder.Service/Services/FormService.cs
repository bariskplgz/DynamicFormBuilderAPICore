using DynamicFormBuilder.Core.Models;
using DynamicFormBuilder.Core.Repositories;
using DynamicFormBuilder.Core.Responses;
using DynamicFormBuilder.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormBuilder.Service.Services
{
    public class FormService : Service<Form>, IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository) : base(formRepository)
        {
            _formRepository = formRepository;
        }
        public async Task<Form> GetByIdWithFieldsAsync(int id)
        {

            return await _formRepository.GetByIdWithFieldsAsync(id);
        }
    }
}
