using FormFiller.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Domain.Entities
{
    public class Generator : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Param>? Params { get; set; }
    }
}
