namespace PressStartApi.DTO.Response
{
    public class UserResponseDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
