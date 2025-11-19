using FormFiller.Domain.Entities;
using FormFiller.Domain.Interfaces;
using FormFiller.Infrasctructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Infrasctructure.Repositories
{
    public class ParamRepository : IParamRepository
    {
        public ApplicationDbContext context;
        public ParamRepository(ApplicationDbContext context)
        {
            this.context = context;
        }   
        public async Task<Param> Create(Param entity)
        {
            var paramEntry = await context.Params.AddAsync(entity);
            return paramEntry.Entity;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Param>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Param?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Param> Update(Param entity)
        {
            throw new NotImplementedException();
        }
    }
}
