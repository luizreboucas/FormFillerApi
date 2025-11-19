using FormFiller.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FormFiller.Domain.Entities
{
    public class Generator : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Param>? Params { get; set; }
        [JsonIgnore]
        public ICollection<Schema> Schemas { get; set; } = new List<Schema>();
    }
}
