using DynamicFormBuilder.Core.Models;

namespace DynamicFormBuilder.Core.Dtos
{
    public class FormDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<FieldDto> fields { get; set; }
    }
}
