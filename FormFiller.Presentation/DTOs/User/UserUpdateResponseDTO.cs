namespace FormFiller.Presentation.DTOs.User
{
    public record UserUpdateResponseDTO(Guid UserId, string Username, string Email, string Phone);
}