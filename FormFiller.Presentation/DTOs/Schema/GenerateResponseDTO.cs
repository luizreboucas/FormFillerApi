using FormFiller.Application.UseCases.Models;

namespace FormFiller.Presentation.DTOs.Schema;

public record class GenerateResponseDTO(List<GeneratedResult> results);
