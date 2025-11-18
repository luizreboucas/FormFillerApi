using System;

namespace FormFiller.Presentation.DTOs.User;

public record UserDTO(Guid Id, string Name, string Email, string Phone);
