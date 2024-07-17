using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicFormBuilder.Core.Dtos
{
    public class FieldDto
    {
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}
