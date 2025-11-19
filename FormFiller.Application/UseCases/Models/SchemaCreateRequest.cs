using System;
using FormFiller.Domain.Entities;

namespace FormFiller.Application.UseCases.Models;

public record SchemaCreateRequest(string Name, List<Guid> GeneratorsIds, Guid UserId);
