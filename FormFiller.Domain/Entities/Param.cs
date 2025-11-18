using FormFiller.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Domain.Entities
{
    public class Param : IEntity
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid GeneratorId { get; set; }
        public Generator? Generator { get; set; }
    }
}
