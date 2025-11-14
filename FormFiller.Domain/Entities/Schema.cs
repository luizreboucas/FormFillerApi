using FormFiller.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFiller.Domain.Entities
{
    public class Schema: IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Generator> Generators { get; set; }
    }
}
