using System;

namespace FormFiller.Application.UseCases.Models;

public record UserCreateResponse(Guid Id, string Username, string Email);
