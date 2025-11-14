using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
