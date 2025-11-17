using System;
using System.ComponentModel.DataAnnotations;

namespace FormFiller.Presentation.DTOs;

public record ApiResponse(bool Success, string? Message, object? Data);
