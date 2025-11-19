using System;
using FormFiller.Application.Exceptions;
using FormFiller.Application.UseCases.Models;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;

namespace FormFiller.Application.UseCases;

public class SchemaUseCases
{
    public ISchemaRepository schemaRepository;
    public IGeneratorRepository generatorRepository;
    public SchemaUseCases(ISchemaRepository schemaRepository, IGeneratorRepository generatorRepository)
    {
        this.schemaRepository = schemaRepository;
        this.generatorRepository = generatorRepository;
    }

    public async Task<SchemaCreateResponse> Create(SchemaCreateRequest request)
    {
        var isAlreadyInTheDB = await schemaRepository.GetAllByName(request.Name);
        if (isAlreadyInTheDB.Any())
        {
            throw new AlreadyInTheDatabase("Registro já existente na base de dados");
        }
        var generators = await generatorRepository.GetByIdList(request.GeneratorsIds);
        var newSchema = new Schema
        {
            Name = request.Name,
            Generators = generators,
            UserId = request.UserId
        };
        var schema = schemaRepository.Create(newSchema);
        if (schema == null)
        {
            throw new Exception("Schema could not be created");
        }
        return new SchemaCreateResponse(newSchema.Id, newSchema.Name, newSchema.Generators.ToList());
    }

    public async Task<List<Schema>> GetAll()
    {
        return await schemaRepository.GetAll();
    }
    public async Task<List<Schema>> GetSchemasByUserId(Guid Id)
    {
        return await schemaRepository.GetAllByUserId(Id);
    }
}
