using System;

namespace FormFiller.Application.UseCases.Models;

public record UserCreateRequest(string Username, string Email, string Password, string Phone);
