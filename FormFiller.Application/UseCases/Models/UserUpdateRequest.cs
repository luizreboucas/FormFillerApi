namespace FormFiller.Application.UseCases.Models
{
    public record UserUpdateRequest(Guid UserId, string? Username, string? Email, string? Phone);
}