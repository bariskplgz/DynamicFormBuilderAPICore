using DynamicFormBuilder.API.Context;
using DynamicFormBuilder.API.Repositories;
using DynamicFormBuilder.Core.Models;
using DynamicFormBuilder.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DynamicFormBuilder.Repository.Repositories
{
    public class FormRepository : GenericRepository<Form>, IFormRepository
    {
        public FormRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Form> GetByIdWithFieldsAsync(int id)
        {
            return await _context.Forms.Include(f => f.Fields).FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
