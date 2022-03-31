using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PressStartApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        [JsonIgnore]
        public virtual Authentication Authentication { get; set; }
    }
}
