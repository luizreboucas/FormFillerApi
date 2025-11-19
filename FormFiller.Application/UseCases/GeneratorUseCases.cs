using System;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;

namespace FormFiller.Application.UseCases;

public class GeneratorUseCases
{
    IGeneratorRepository generatorRepository;
    public GeneratorUseCases(IGeneratorRepository _generatorRepository)
    {
        this.generatorRepository = _generatorRepository;
    }

    public async Task<List<Generator>> GetAllByIdList(List<Guid> ids)
    {
        var generators = await generatorRepository.GetByIdList(ids);
        return generators;
    }

    public async Task<List<Generator>> GetAll()
    {
        return await generatorRepository.GetAll();
    }
}
