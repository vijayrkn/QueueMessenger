using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MessageModels
{
    public class Employee
    {
        [Key]
        [JsonPropertyName("EmployeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("FirstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string? LastName { get; set; }
    }
}
