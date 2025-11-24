namespace FormFiller.Presentation.DTOs.Schema;

public record class GenerateRequestDTO(List<Guid>? paramsIds, Guid schemaId);
