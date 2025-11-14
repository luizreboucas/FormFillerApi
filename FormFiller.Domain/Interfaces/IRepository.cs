using FormFiller.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Domain.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        public Task<T> Create(T entity);
        public void Delete(Guid id);
        public Task<List<T>> GetAll();
        public Task<T> Update(T entity);
        public Task<T?> GetById(Guid id);
    }
}
