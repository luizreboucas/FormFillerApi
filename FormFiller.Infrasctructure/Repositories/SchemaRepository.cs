using System;
using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using FormFiller.Infrasctructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FormFiller.Infrasctructure.Repositories;

public class SchemaRepository : ISchemaRepository
{
    public ApplicationDbContext context;
    public SchemaRepository(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<Schema> Create(Schema entity)
    {
        var newSchema = await context.Schemas.AddAsync(entity);
        await context.SaveChangesAsync();
        return newSchema.Entity;
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Schema>> GetAll()
    {
        return await context.Schemas.ToListAsync();
    }

    public Task<List<Schema>> GetAllByName(string name)
    {
        return context.Schemas.Where(s => s.Name.Contains(name)).ToListAsync();
    }

    public async Task<List<Schema>> GetAllByUserId(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        }
        var schemas = await context.Schemas.Where(s => s.UserId == userId).ToListAsync();
        return schemas;
    }

    public Task<Schema?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Schema> Update(Schema entity)
    {
        throw new NotImplementedException();
    }
}
