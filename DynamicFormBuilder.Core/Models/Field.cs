using System.Text.Json.Serialization;

namespace DynamicFormBuilder.Core.Models
{
    public class Field
    {
        public int Id { get; set; }
        public bool Required { get; set; }
        public string Name { get; set; }    
        public string DataType { get; set; }
        public int FormId { get; set; }
        [JsonIgnore]
        public Form Form { get; set; }
    }
}   