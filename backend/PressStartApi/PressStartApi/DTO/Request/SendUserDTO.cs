namespace PressStartApi.DTO.Request
{
    public class SendUserDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
    }
}
