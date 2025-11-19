using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace FormFiller.Application.UseCases.Models
{
    public record CreateParamRequest(Guid GeneratorId, string Value);
}
