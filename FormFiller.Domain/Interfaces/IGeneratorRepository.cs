using System;
using FormFiller.Domain.Entities;

namespace FormFiller.Domain.Interfaces;

public interface IGeneratorRepository : IRepository<Generator>
{
    public Task<List<Generator>> GetByIdList(List<Guid> ids);
}
