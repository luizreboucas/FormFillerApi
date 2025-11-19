using System;
using FormFiller.Domain.Entities;

namespace FormFiller.Domain.Interfaces;

public interface ISchemaRepository : IRepository<Schema>
{
    public Task<List<Schema>> GetAllByName(string name);
    public Task<List<Schema>> GetAllByUserId(Guid userId);
}
