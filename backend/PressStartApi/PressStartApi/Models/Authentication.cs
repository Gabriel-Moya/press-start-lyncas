using System.ComponentModel.DataAnnotations;

namespace PressStartApi.Models
{
    public class Authentication
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
