using System;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using FormFiller.Infrasctructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FormFiller.Infrasctructure.Repositories;

public class GeneratorRepository : IGeneratorRepository
{
    public ApplicationDbContext _context;
    public GeneratorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<Generator> Create(Generator entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Generator>> GetAll()
    {
        return await _context.Generators.ToListAsync();
    }

    public Task<Generator?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Generator>> GetByIdList(List<Guid> ids)
    {
        var generators = await _context.Generators.Where(g => ids.Contains(g.Id)).ToListAsync();
        return generators;
    }

    public Task<Generator> Update(Generator entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Generator>> GetAllByName(string name)
    {
        return await _context.Generators.Where(g => g.Name.Contains(name)).ToListAsync();
    }
}
