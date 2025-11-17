namespace FormFiller.Presentation.DTOs.User
{
    public record UserUpdateRequestDTO(string? Username, string? Email, string? Phone, string? Password);
}