namespace FormFiller.Application.UseCases.Models
{
    public record UserUpdateResponse(Guid Id, string? Username, string? Email, string? Phone);
}