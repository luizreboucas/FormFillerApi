using System;
using FormFiller.Application.Exceptions;
using FormFiller.Application.UseCases.Models;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;

namespace FormFiller.Application.UseCases;

public class SchemaUserCases
{
    public ISchemaRepository schemaRepository;
    public SchemaUserCases(ISchemaRepository schemaRepository)
    {
        this.schemaRepository = schemaRepository;
    }

    public async Task<SchemaCreateResponse> Create(SchemaCreateRequest request, Guid userId)
    {
        var newSchema = new Schema
        {
            Name = request.Name,
            Generators = request.Generators,
            UserId = request.UserId
        };
        var isAlreadyInTheDB = await schemaRepository.GetById(newSchema.Id);
        if (isAlreadyInTheDB != null)
        {
            throw new AlreadyInTheDatabase("Registro já existente na base de dados");
        }
        var schema = schemaRepository.Create(newSchema);
        if (schema == null)
        {
            throw new Exception("Schema could not be created");
        }
        return new SchemaCreateResponse(newSchema.Id, newSchema.Name, newSchema.Generators);
    }

    public async Task<List<Schema>> GetAll()
    {
        return await schemaRepository.GetAll();
    }
}
