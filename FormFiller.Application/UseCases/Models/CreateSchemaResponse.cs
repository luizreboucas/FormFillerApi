using FormFiller.Domain.Entities;

namespace FormFiller.Application.UseCases.Models;

public record SchemaCreateResponse(Guid Id, string Name, List<Generator> Generators);