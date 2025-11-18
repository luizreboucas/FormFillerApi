using FormFiller.Presentation.DTOs.Generator;

namespace FormFiller.Presentation.DTOs.Schema;

public record class SchemaCreateDTO(string Name, List<GeneratorDTO> Generators, Guid UserId);
