using FormFiller.Domain.Entities;

namespace FormFiller.Application.UseCases.Models;

public record class GeneratedResultsResponse(List<GeneratedResult> results);