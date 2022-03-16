using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual Authentication Authentication { get; set; }
    }
}
