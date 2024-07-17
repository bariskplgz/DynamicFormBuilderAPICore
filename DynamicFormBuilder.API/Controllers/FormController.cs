using DynamicFormBuilder.Core.Dtos;
using DynamicFormBuilder.Core.Models;
using DynamicFormBuilder.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFormBuilder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;


        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpGet("getForms")]
        public async Task<ActionResult<IQueryable<Form>>> GetForms()
        {
            var forms = await _formService.GetAllAsync();
            return Ok(forms);
        }

        [HttpGet("getFormByIdWithFields/{id}")]
        public async Task<ActionResult<Form>> GetFormById(int id)
        {
            var form = await _formService.GetByIdWithFieldsAsync(id);
            return Ok(form);
        }


        [HttpPost("addForm")]
        public async Task<ActionResult> AddForm(FormDto form)
        {
            try
            {
                var newForm = new Form
                {
                    Name = form.Name,
                    Description = form.Description,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                };

                var fields = form.fields.Select(f => new Field
                {
                    Name = f.Name,
                    DataType = f.DataType,
                    Required = f.Required,
                    Form = newForm
                }).ToList();

                newForm.Fields = fields;

                await _formService.AddAsync(newForm);
                return Ok(new { message = "Form successfully added." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            
        }
    }
}
